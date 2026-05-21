using System.Collections.Generic;

namespace Story.Model
{
    public class StoryDefinition
    {
        public string Title { get; set; }               // metadata: titlul
        public string StartBlock { get; set; }          // id-ul blocului de start

        public List<StatePropertyDefinition> Properties { get; set; } = new List<StatePropertyDefinition>();
        public List<StoryBlock> Blocks { get; set; } = new List<StoryBlock>();
    }
}