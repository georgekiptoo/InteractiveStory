using System.Collections.Generic;

namespace Story.Model
{
    public class StoryBlock
    {
        public string Id { get; set; }                  // ex: "forest.clearing"
        public string Text { get; set; }                // textul narativ
        public string BackgroundImage { get; set; }     // opțional, ex: "images/forest.jpg"
        public bool IsEnding { get; set; }              // marcaj bloc final

        public List<DecisionDefinition> Decisions { get; set; } = new List<DecisionDefinition>();
    }
}