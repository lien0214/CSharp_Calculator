using CalculatorCore.Abstracts;
using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.Interfaces;

namespace CalculatorCore.ExpressionTreeNodes.RealTreeNodes
{
    internal class NegateTreeNode : UnaryExpressionTreeNode
    {
        public NegateTreeNode(string textFormula, string text, decimal value, ExpressionTreeNode? child)
            : base(textFormula, text, value, child) { }
        public NegateTreeNode(NegateTreeNode node) : base(node) { }
        public override void RealNodeAccept(IRealNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
