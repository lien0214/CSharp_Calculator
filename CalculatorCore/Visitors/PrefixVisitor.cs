using CalculatorCore.Abstracts;
using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using System.Text;

namespace CalculatorCore.Visitors
{
    internal class PrefixVisitor : AryNodeVisitor
    {
        public StringBuilder Preorder { get ; private set; } = new();
        public override void Visit(NullaryExpressionTreeNode node)
        {
            Preorder.Append(node.Text);
        }

        public override void Visit(UnaryExpressionTreeNode node)
        {
            Preorder.Append(node.Text);
            Preorder.Append(" ");
            node.Child!.AryNodeAccept(this);
        }

        public override void Visit(BinaryExpressionTreeNode node)
        {
            Preorder.Append(node.Text);
            Preorder.Append(" ");
            node.Left!.AryNodeAccept(this);
            Preorder.Append(" ");
            node.Right!.AryNodeAccept(this);
        }
    }
}
