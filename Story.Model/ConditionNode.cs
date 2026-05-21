using System.Collections.Generic;

namespace Story.Model
{
    // Clasă de bază abstractă — toate nodurile moștenesc din asta
    public abstract class ConditionNode
    {
        public abstract ConditionType Type { get; }
    }

    public enum ConditionType
    {
        COMPARISON,
        AND,
        OR
    }

    // Frunza — compară o proprietate cu o valoare
    public class ComparisonCondition : ConditionNode
    {
        public override ConditionType Type => ConditionType.COMPARISON;

        public string Property { get; set; }   // ex: "inventory.money"
        public string Operator { get; set; }   // <, <=, >, >=, ==, !=
        public int Value { get; set; }
    }

    // AND — toate sub-condițiile trebuie să fie adevărate
    public class AndCondition : ConditionNode
    {
        public override ConditionType Type => ConditionType.AND;

        public List<ConditionNode> Conditions { get; set; } = new List<ConditionNode>();
    }

    // OR — cel puțin o sub-condiție trebuie să fie adevărată
    public class OrCondition : ConditionNode
    {
        public override ConditionType Type => ConditionType.OR;

        public List<ConditionNode> Conditions { get; set; } = new List<ConditionNode>();
    }
}