using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.ExpressionTreeNodes.RealTreeNodes;

namespace CalculatorCore.Abstracts
{
    internal abstract class RealNodeVisitor
    {
        public abstract void Visit(OperatorTreeNode node);
        public abstract void Visit(EqualTreeNode node);
        public abstract void Visit(ParenthesesTreeNode node);
        public abstract void Visit(SquareRootTreeNode node);
        public abstract void Visit(NegateTreeNode node);
        public abstract void Visit(NumberTreeNode node);

    }
}
