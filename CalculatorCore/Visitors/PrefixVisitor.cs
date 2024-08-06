using CalculatorCore.Abstracts;
using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using System.Text;

namespace CalculatorCore.Visitors
{
    internal class PrefixVisitor : AryNodeVisitor
    {
        public StringBuilder Prefix { get ; private set; } = new();
        public override void Visit(NullaryExpressionTreeNode node)
        {
            Prefix.Append(node.Text);
        }

        public override void Visit(UnaryExpressionTreeNode node)
        {
            Prefix.Append(node.Text);
            Prefix.Append(" ");
            node.Child!.AryNodeAccept(this);
        }

        public override void Visit(BinaryExpressionTreeNode node)
        {
            Prefix.Append(node.Text);
            Prefix.Append(" ");
            node.Left!.AryNodeAccept(this);
            Prefix.Append(" ");
            node.Right!.AryNodeAccept(this);
        }
    }
}
