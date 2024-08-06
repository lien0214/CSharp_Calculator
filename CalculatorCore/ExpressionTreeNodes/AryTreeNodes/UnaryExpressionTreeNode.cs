using CalculatorCore.Abstracts;
using CalculatorCore.Interfaces;
namespace CalculatorCore.ExpressionTreeNodes.AryTreeNodes
{
    internal class UnaryExpressionTreeNode : ExpressionTreeNode
    {
        public ExpressionTreeNode? Child { get; set; }
        public UnaryExpressionTreeNode(string textFormula, string text, decimal value, ExpressionTreeNode? child)
            : base(textFormula, text, value)
        {
            Child = child;
        }
        public UnaryExpressionTreeNode(UnaryExpressionTreeNode node) : base(node.TextFormula, node.Text, node.Value) { }
        public override void RealNodeAccept(IRealNodeVisitor visitor) { }
        public override void AryNodeAccept(IAryNodeVisitor visitor) => visitor.Visit(this);
    }
}
