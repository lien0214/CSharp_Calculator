using CalculatorCore.Abstracts;
using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore.Visitors
{
    internal class InfixVisitor : AryNodeVisitor
    {
        public StringBuilder Infix { get; private set; } = new();
        public override void Visit(NullaryExpressionTreeNode node)
        {
            Infix.Append(node.Text);
        }

        public override void Visit(UnaryExpressionTreeNode node)
        {
            Infix.Append(node.Text);
            Infix.Append(" ");
            node.Child!.AryNodeAccept(this);
        }

        public override void Visit(BinaryExpressionTreeNode node)
        {
            node.Left!.AryNodeAccept(this);
            Infix.Append(" ");
            Infix.Append(node.Text);
            Infix.Append(" ");
            node.Right!.AryNodeAccept(this);
        }
    }
}
