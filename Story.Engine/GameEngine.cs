using System;
using System.Collections.Generic;
using System.Linq;
using Story.Model;

namespace Story.Engine
{
    public class GameEngine
    {
        public StoryDefinition Story { get; private set; }
        public GameState State { get; private set; }

        // Acces rapid la blocuri după id (Dictionary e O(1))
        private Dictionary<string, StoryBlock> _blocksById;

        public GameEngine(StoryDefinition story)
        {
            Story = story ?? throw new ArgumentNullException(nameof(story));

            // Construim dicționarul pentru acces rapid (§12.1 din temă)
            _blocksById = new Dictionary<string, StoryBlock>();
            foreach (var block in story.Blocks)
                _blocksById[block.Id] = block;

            // Inițializăm starea
            State = new GameState();
            State.CurrentBlockId = story.StartBlock;
            foreach (var prop in story.Properties)
                State.SetValue(prop.Key, prop.Initial);
        }

        // Returnează blocul curent în care se află jucătorul
        public StoryBlock GetCurrentBlock()
        {
            if (_blocksById.TryGetValue(State.CurrentBlockId, out var block))
                return block;

            throw new InvalidOperationException(
                $"Blocul curent '{State.CurrentBlockId}' nu există în poveste.");
        }

        // Returnează doar deciziile vizibile (cu condiții îndeplinite)
        public List<DecisionDefinition> GetAvailableDecisions()
        {
            var current = GetCurrentBlock();
            var result = new List<DecisionDefinition>();

            foreach (var decision in current.Decisions)
            {
                if (ConditionEvaluator.Evaluate(decision.Condition, State))
                    result.Add(decision);
            }
            return result;
        }

        // Aplică o decizie: efectele + tranziția la blocul țintă
        // Întoarce blocul în care s-a ajuns (poate fi diferit de TargetBlock dacă a apărut redirecționare automată)
        public StoryBlock ApplyDecision(DecisionDefinition decision)
        {
            if (decision == null)
                throw new ArgumentNullException(nameof(decision));

            // 1. Aplică efectele asupra stării
            foreach (var effect in decision.Effects)
                ApplyEffect(effect);

            // 2. Verifică redirecționările automate (min/max)
            string redirectBlock = CheckMinMaxRedirects();

            // 3. Decide blocul țintă
            string nextBlockId = redirectBlock ?? decision.TargetBlock;

            if (!_blocksById.ContainsKey(nextBlockId))
                throw new InvalidOperationException(
                    $"Blocul țintă '{nextBlockId}' nu există în poveste.");

            State.CurrentBlockId = nextBlockId;
            return _blocksById[nextBlockId];
        }

        // Aplică un singur efect cu clamping în [min, max]
        private void ApplyEffect(EffectDefinition effect)
        {
            var propDef = Story.Properties.FirstOrDefault(p => p.Key == effect.Property);
            if (propDef == null)
                throw new InvalidOperationException(
                    $"Proprietatea '{effect.Property}' nu este definită în poveste.");

            int currentValue = State.GetValue(effect.Property);
            int newValue;

            switch (effect.Type)
            {
                case EffectType.ADD:
                    newValue = currentValue + effect.Value;
                    break;
                case EffectType.SET:
                    newValue = effect.Value;
                    break;
                default:
                    throw new InvalidOperationException(
                        $"Tip de efect necunoscut: {effect.Type}");
            }

            // Clamping: limitează valoarea la intervalul [min, max] (§12.2 din temă)
            newValue = Math.Max(propDef.Min, Math.Min(propDef.Max, newValue));

            State.SetValue(effect.Property, newValue);
        }

        // Verifică dacă vreo proprietate a atins min/max și are redirect definit
        // Returnează id-ul blocului de redirect, sau null dacă nu e cazul
        private string CheckMinMaxRedirects()
        {
            foreach (var prop in Story.Properties)
            {
                int current = State.GetValue(prop.Key);

                if (current <= prop.Min && !string.IsNullOrEmpty(prop.OnMinBlock))
                    return prop.OnMinBlock;

                if (current >= prop.Max && !string.IsNullOrEmpty(prop.OnMaxBlock))
                    return prop.OnMaxBlock;
            }
            return null;
        }

        // Resetează jocul la starea inițială (pentru meniul „Restart")
        public void Restart()
        {
            State = new GameState();
            State.CurrentBlockId = Story.StartBlock;
            foreach (var prop in Story.Properties)
                State.SetValue(prop.Key, prop.Initial);
        }
    }
}