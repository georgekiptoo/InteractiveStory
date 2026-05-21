using System.Collections.Generic;

namespace Story.Model
{
    public class DecisionDefinition
    {
        public string Text { get; set; }                // textul afișat utilizatorului
        public string TargetBlock { get; set; }         // id-ul blocului spre care duce
        public string IconPath { get; set; }            // opțional, ex: "images/icon_key.png"

        public ConditionNode Condition { get; set; }    // opțional, poate fi null

        public List<EffectDefinition> Effects { get; set; } = new List<EffectDefinition>();
    }
}