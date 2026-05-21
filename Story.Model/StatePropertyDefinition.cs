namespace Story.Model
{
    public class StatePropertyDefinition
    {
        public string Key { get; set; }           // ex: "player.life"
        public string HudLabel { get; set; }      // ex: "Viață"
        public int Min { get; set; }
        public int Max { get; set; }
        public int Initial { get; set; }
        public bool VisibleInHud { get; set; }
        public int HudOrder { get; set; }

        // Opționale: bloc țintă la atingerea minimului/maximului (poate fi null)
        public string OnMinBlock { get; set; }
        public string OnMaxBlock { get; set; }
    }
}