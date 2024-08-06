using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.Interfaces;
using System.Text;

namespace CalculatorCore.Visitors
{
    internal class PrefixVisitor : IAryNodeVisitor
    {
        public StringBuilder Preorder { get ; private set; } = new();
        public void Visit(NullaryExpressionTreeNode node)
        {
            Preorder.Append(node.Text);
        }

        public void Visit(UnaryExpressionTreeNode node)
        {
            Preorder.Append(node.Text);
            Preorder.Append(' ');
            node.Child!.AryNodeAccept(this);
        }

        public void Visit(BinaryExpressionTreeNode node)
        {
            Preorder.Append(node.Text);
            Preorder.Append(' ');
            node.Left!.AryNodeAccept(this);
            Preorder.Append(' ');
            node.Right!.AryNodeAccept(this);
        }
    }
}
