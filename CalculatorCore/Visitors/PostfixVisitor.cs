using CalculatorCore.Abstracts;
using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore.Visitors
{
    internal class PostfixVisitor : AryNodeVisitor
    {
        public StringBuilder Postfix { get; private set; } = new();
        public override void Visit(NullaryExpressionTreeNode node)
        {
            Postfix.Append(node.Text);
        }

        public override void Visit(UnaryExpressionTreeNode node)
        {
            node.Child!.AryNodeAccept(this);
            Postfix.Append(" ");
            Postfix.Append(node.Text);
        }

        public override void Visit(BinaryExpressionTreeNode node)
        {
            node.Left!.AryNodeAccept(this);
            Postfix.Append(" ");
            node.Right!.AryNodeAccept(this);
            Postfix.Append(" ");
            Postfix.Append(node.Text);
        }
    }
}
