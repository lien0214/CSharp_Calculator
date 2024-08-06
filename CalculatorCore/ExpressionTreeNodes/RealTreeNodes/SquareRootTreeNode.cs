using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.Abstracts;
using CalculatorCore.Interfaces;

namespace CalculatorCore.ExpressionTreeNodes.RealTreeNodes
{
    internal class SquareRootTreeNode : UnaryExpressionTreeNode
    {
        public SquareRootTreeNode(string textFormula, string text, decimal value, ExpressionTreeNode? child)
            : base(textFormula, text, value, child) { }
        public SquareRootTreeNode(SquareRootTreeNode node) : base(node) { }
        public override void RealNodeAccept(IRealNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
