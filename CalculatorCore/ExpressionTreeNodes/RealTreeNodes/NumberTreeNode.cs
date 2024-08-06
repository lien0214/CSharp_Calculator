using CalculatorCore.Abstracts;
using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;

namespace CalculatorCore.ExpressionTreeNodes.RealTreeNodes
{
    internal class NumberTreeNode : NullaryExpressionTreeNode
    {
        public NumberTreeNode(string textFormula, string text, decimal value)
            : base(textFormula, text, value) { }
        public NumberTreeNode(NumberTreeNode node) : base(node) { }
        public override void RealNodeAccept(RealNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
