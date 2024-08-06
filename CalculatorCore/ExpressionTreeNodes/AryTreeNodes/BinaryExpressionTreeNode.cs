using CalculatorCore.Abstracts;
using CalculatorCore.Interfaces;
namespace CalculatorCore.ExpressionTreeNodes.AryTreeNodes
{
    internal class BinaryExpressionTreeNode : ExpressionTreeNode
    {
        public ExpressionTreeNode? Left { get; set; }
        public ExpressionTreeNode? Right { get; set; }
        public BinaryExpressionTreeNode(string textFormula, string text, decimal value, ExpressionTreeNode? left, ExpressionTreeNode? right)
            : base(textFormula, text, value)
        {
            Left = left;
            Right = right;
        }
        public BinaryExpressionTreeNode(BinaryExpressionTreeNode node) : base(node.TextFormula, node.Text, node.Value)
        {
            Left = node.Left;
            Right = node.Right;
        }

        public override void RealNodeAccept(IRealNodeVisitor visitor) { }
        public override void AryNodeAccept(IAryNodeVisitor visitor) => visitor.Visit(this);
    }
}
