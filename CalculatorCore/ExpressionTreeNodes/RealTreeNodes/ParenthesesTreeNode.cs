using CalculatorCore.Abstracts;
using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;

namespace CalculatorCore.ExpressionTreeNodes.RealTreeNodes
{
    internal class ParenthesesTreeNode : UnaryExpressionTreeNode
    {
        public ParenthesesTreeNode(string textFormula, string text, decimal value, ExpressionTreeNode? child)
            : base(textFormula, text, value, child) { }
        public ParenthesesTreeNode(ParenthesesTreeNode node) : base(node) { }
        public override void RealNodeAccept(RealNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
