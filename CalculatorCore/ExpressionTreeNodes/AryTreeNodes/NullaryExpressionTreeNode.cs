using CalculatorCore.Abstracts;
using CalculatorCore.Utils;
namespace CalculatorCore.ExpressionTreeNodes.AryTreeNodes
{
    internal class NullaryExpressionTreeNode : ExpressionTreeNode
    {
        public NullaryExpressionTreeNode(string textFormula, string text, decimal value) : base(textFormula, text, value) { }
        public NullaryExpressionTreeNode(NullaryExpressionTreeNode node) : base(node.TextFormula, node.Text, node.Value) { }
        public override void RealNodeAccept(RealNodeVisitor visitor) { }
        public override void AryNodeAccept(AryNodeVisitor visitor) => visitor.Visit(this);
    }
}
