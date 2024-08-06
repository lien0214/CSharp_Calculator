using CalculatorCore.ExpressionTreeNodes.RealTreeNodes;

namespace CalculatorCore.Utils
{
    internal static class NodeExtensions
    {
        public static List<string> Expression(this SquareRootTreeNode node)
        {
            return [Constants.SQUARE_ROOT.ToString(), Constants.LEFT_PARENTHESIS.ToString(), Constants.RIGHT_PARENTHESIS.ToString()];
        }

        public static List<string> Expression(this ParenthesesTreeNode node)
        {
            return [string.Empty, Constants.LEFT_PARENTHESIS.ToString(), Constants.RIGHT_PARENTHESIS.ToString()];
        }

        public static List<string> Expression(this NegateTreeNode node)
        {
            return [Constants.MINUS.ToString(), Constants.LEFT_PARENTHESIS.ToString(), Constants.RIGHT_PARENTHESIS.ToString()];
        }

        public static List<string> Expression(this EqualTreeNode node)
        {
            return [string.Empty, string.Empty, Constants.EQUAL.ToString()];
        }
    }
}
