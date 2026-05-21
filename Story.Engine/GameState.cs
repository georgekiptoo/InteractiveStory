using System.Collections.Generic;
using Story.Model;

namespace Story.Engine
{
    public class GameState
    {
        // Valorile curente ale proprietăților, indexate după cheie
        // Ex: properties["player.life"] = 50
        public Dictionary<string, int> Properties { get; set; } = new Dictionary<string, int>();

        // Id-ul blocului în care se află jucătorul acum
        public string CurrentBlockId { get; set; }

        // Citește valoarea unei proprietăți; întoarce 0 dacă nu există
        public int GetValue(string key)
        {
            if (Properties.ContainsKey(key))
                return Properties[key];
            return 0;
        }

        // Scrie valoarea unei proprietăți (fără clamping aici — clamping-ul se face în engine)
        public void SetValue(string key, int value)
        {
            Properties[key] = value;
        }
    }
}