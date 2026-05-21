using System.Collections.Generic;
using System.Linq;
using Story.Model;

namespace Story.Engine
{
    public class StoryValidator
    {
        private StoryDefinition _story;
        private List<string> _errors;

        public StoryValidator(StoryDefinition story)
        {
            _story = story;
            _errors = new List<string>();
        }

        public List<string> Validate()
        {
            _errors.Clear();

            ValidateMetadata();
            ValidateProperties();
            ValidateBlocks();

            return _errors;
        }

        private void ValidateMetadata()
        {
            if (string.IsNullOrWhiteSpace(_story.Title))
                _errors.Add("Titlul poveștii lipsește.");

            if (string.IsNullOrWhiteSpace(_story.StartBlock))
                _errors.Add("Blocul de start nu e specificat.");
            else if (!_story.Blocks.Any(b => b.Id == _story.StartBlock))
                _errors.Add("Blocul de start \"" + _story.StartBlock + "\" nu există în poveste.");
        }

        private void ValidateProperties()
        {
            var keys = new HashSet<string>();
            foreach (var prop in _story.Properties)
            {
                if (string.IsNullOrWhiteSpace(prop.Key))
                {
                    _errors.Add("O proprietate are cheia goală.");
                    continue;
                }

                if (!keys.Add(prop.Key))
                    _errors.Add("Proprietatea \"" + prop.Key + "\" e duplicată.");

                if (prop.Min > prop.Max)
                    _errors.Add("Proprietatea \"" + prop.Key + "\": min > max.");

                if (prop.Initial < prop.Min || prop.Initial > prop.Max)
                    _errors.Add("Proprietatea \"" + prop.Key + "\": valoarea inițială nu e în [min, max].");

                if (!string.IsNullOrEmpty(prop.OnMinBlock) &&
                    !_story.Blocks.Any(b => b.Id == prop.OnMinBlock))
                    _errors.Add("Proprietatea \"" + prop.Key + "\": blocul OnMin \"" + prop.OnMinBlock + "\" nu există.");

                if (!string.IsNullOrEmpty(prop.OnMaxBlock) &&
                    !_story.Blocks.Any(b => b.Id == prop.OnMaxBlock))
                    _errors.Add("Proprietatea \"" + prop.Key + "\": blocul OnMax \"" + prop.OnMaxBlock + "\" nu există.");
            }
        }

        private void ValidateBlocks()
        {
            var ids = new HashSet<string>();
            var propKeys = new HashSet<string>(_story.Properties.Select(p => p.Key));
            var blockIds = new HashSet<string>(_story.Blocks.Select(b => b.Id));

            foreach (var block in _story.Blocks)
            {
                if (string.IsNullOrWhiteSpace(block.Id))
                {
                    _errors.Add("Un bloc are id-ul gol.");
                    continue;
                }

                if (!ids.Add(block.Id))
                    _errors.Add("Blocul \"" + block.Id + "\" e duplicat.");

                ValidateDecisions(block, blockIds, propKeys);
            }
        }

        private void ValidateDecisions(StoryBlock block,
            HashSet<string> blockIds, HashSet<string> propKeys)
        {
            foreach (var decision in block.Decisions)
            {
                string prefix = "Blocul \"" + block.Id + "\", decizia \"" + decision.Text + "\": ";

                if (string.IsNullOrWhiteSpace(decision.TargetBlock))
                    _errors.Add(prefix + "nu are bloc țintă.");
                else if (!blockIds.Contains(decision.TargetBlock))
                    _errors.Add(prefix + "blocul țintă \"" + decision.TargetBlock + "\" nu există.");

                foreach (var effect in decision.Effects)
                {
                    if (string.IsNullOrWhiteSpace(effect.Property))
                        _errors.Add(prefix + "un efect nu are proprietate specificată.");
                    else if (!propKeys.Contains(effect.Property))
                        _errors.Add(prefix + "efectul referă proprietatea \"" + effect.Property + "\" care nu există.");
                }

                if (decision.Condition != null)
                    ValidateCondition(decision.Condition, propKeys, prefix);
            }
        }

        private void ValidateCondition(ConditionNode node,
            HashSet<string> propKeys, string prefix)
        {
            if (node is ComparisonCondition cmp)
            {
                if (string.IsNullOrWhiteSpace(cmp.Property))
                    _errors.Add(prefix + "o condiție nu are proprietate specificată.");
                else if (!propKeys.Contains(cmp.Property))
                    _errors.Add(prefix + "condiția referă proprietatea \"" + cmp.Property + "\" care nu există.");
            }
            else if (node is AndCondition and)
            {
                foreach (var child in and.Conditions)
                    ValidateCondition(child, propKeys, prefix);
            }
            else if (node is OrCondition or)
            {
                foreach (var child in or.Conditions)
                    ValidateCondition(child, propKeys, prefix);
            }
        }
    }
}