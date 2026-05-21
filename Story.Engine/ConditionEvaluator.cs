using System;
using Story.Model;

namespace Story.Engine
{
    public static class ConditionEvaluator
    {
        // Punctul de intrare: evaluează orice condiție
        // Dacă e null → consideră că e îndeplinită (decizii fără condiție)
        public static bool Evaluate(ConditionNode node, GameState state)
        {
            if (node == null)
                return true;

            switch (node)
            {
                case ComparisonCondition cmp:
                    return EvaluateComparison(cmp, state);

                case AndCondition and:
                    foreach (var child in and.Conditions)
                        if (!Evaluate(child, state))
                            return false;
                    return true;

                case OrCondition or:
                    foreach (var child in or.Conditions)
                        if (Evaluate(child, state))
                            return true;
                    return false;

                default:
                    throw new InvalidOperationException(
                        $"Tip de condiție necunoscut: {node.GetType().Name}");
            }
        }

        private static bool EvaluateComparison(ComparisonCondition cmp, GameState state)
        {
            int actual = state.GetValue(cmp.Property);
            int expected = cmp.Value;

            switch (cmp.Operator)
            {
                case "<": return actual < expected;
                case "<=": return actual <= expected;
                case ">": return actual > expected;
                case ">=": return actual >= expected;
                case "==": return actual == expected;
                case "!=": return actual != expected;
                default:
                    throw new InvalidOperationException(
                        $"Operator necunoscut: {cmp.Operator}");
            }
        }
    }
}