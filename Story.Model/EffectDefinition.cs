namespace Story.Model
{
    public class EffectDefinition
    {
        public EffectType Type { get; set; }      // ADD sau SET
        public string Property { get; set; }      // ex: "inventory.money"
        public int Value { get; set; }            // delta (pentru ADD) sau valoarea nouă (pentru SET)
    }

    public enum EffectType
    {
        ADD,    // value se adună la proprietate
        SET     // value devine valoarea proprietății
    }
}