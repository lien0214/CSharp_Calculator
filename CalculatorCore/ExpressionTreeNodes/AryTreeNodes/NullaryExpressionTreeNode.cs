using CalculatorCore.Abstracts;
using CalculatorCore.Interfaces;
using CalculatorCore.Utils;
namespace CalculatorCore.ExpressionTreeNodes.AryTreeNodes
{
    internal class NullaryExpressionTreeNode : ExpressionTreeNode
    {
        public NullaryExpressionTreeNode(string textFormula, string text, decimal value) : base(textFormula, text, value) { }
        public NullaryExpressionTreeNode(NullaryExpressionTreeNode node) : base(node.TextFormula, node.Text, node.Value) { }
        public override void RealNodeAccept(IRealNodeVisitor visitor) { }
        public override void AryNodeAccept(IAryNodeVisitor visitor) => visitor.Visit(this);
    }
}
