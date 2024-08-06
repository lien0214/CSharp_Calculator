using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;

namespace CalculatorCore.Abstracts
{
    internal abstract class AryNodeVisitor
    {
        public abstract void Visit(NullaryExpressionTreeNode node);
        public abstract void Visit(UnaryExpressionTreeNode node);
        public abstract void Visit(BinaryExpressionTreeNode node);
    }
}
