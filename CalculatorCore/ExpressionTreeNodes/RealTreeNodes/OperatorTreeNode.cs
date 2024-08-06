using CalculatorCore.Abstracts;
using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.Interfaces;
namespace CalculatorCore.ExpressionTreeNodes.RealTreeNodes
{
    internal class OperatorTreeNode : BinaryExpressionTreeNode
    {
        public OperatorTreeNode(OperatorTreeNode node) : base(node) { }
        public OperatorTreeNode(string textFormula, string text, decimal value, ExpressionTreeNode? left, ExpressionTreeNode? right)
            : base(textFormula, text, value, left, right) { }
        public override void RealNodeAccept(IRealNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
