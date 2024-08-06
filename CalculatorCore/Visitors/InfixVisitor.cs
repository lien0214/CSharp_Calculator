using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.Interfaces;
using System.Text;

namespace CalculatorCore.Visitors
{
    internal class InfixVisitor : IAryNodeVisitor
    {
        public StringBuilder Inorder { get; private set; } = new();
        public void Visit(NullaryExpressionTreeNode node)
        {
            Inorder.Append(node.Text);
        }

        public void Visit(UnaryExpressionTreeNode node)
        {
            Inorder.Append(node.Text);
            Inorder.Append(' ');
            node.Child!.AryNodeAccept(this);
        }

        public void Visit(BinaryExpressionTreeNode node)
        {
            node.Left!.AryNodeAccept(this);
            Inorder.Append(' ');
            Inorder.Append(node.Text);
            Inorder.Append(' ');
            node.Right!.AryNodeAccept(this);
        }
    }
}
