using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.Interfaces;
using System.Text;

namespace CalculatorCore.Visitors
{
    internal class PostfixVisitor : IAryNodeVisitor
    {
        public StringBuilder Postfix { get; private set; } = new();
        public void Visit(NullaryExpressionTreeNode node)
        {
            Postfix.Append(node.Text);
        }

        public void Visit(UnaryExpressionTreeNode node)
        {
            node.Child!.AryNodeAccept(this);
            Postfix.Append(' ');
            Postfix.Append(node.Text);
        }

        public void Visit(BinaryExpressionTreeNode node)
        {
            node.Left!.AryNodeAccept(this);
            Postfix.Append(' ');
            node.Right!.AryNodeAccept(this);
            Postfix.Append(' ');
            Postfix.Append(node.Text);
        }
    }
}
