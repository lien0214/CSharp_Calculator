using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.Abstracts;
using CalculatorCore.Interfaces;

namespace CalculatorCore.ExpressionTreeNodes.RealTreeNodes
{
    internal class EqualTreeNode : UnaryExpressionTreeNode
    {
        public EqualTreeNode(string textFormula, string text, decimal value, ExpressionTreeNode? child)
            : base(textFormula, text, value, child) { }
        public EqualTreeNode(EqualTreeNode node) : base(node) { }
        public override void RealNodeAccept(IRealNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
