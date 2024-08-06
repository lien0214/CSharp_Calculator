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
        public StringBuilder Inorder { get; private set; } = new();
        public override void Visit(NullaryExpressionTreeNode node)
        {
            Inorder.Append(node.Text);
        }

        public override void Visit(UnaryExpressionTreeNode node)
        {
            Inorder.Append(node.Text);
            Inorder.Append(" ");
            node.Child!.AryNodeAccept(this);
        }

        public override void Visit(BinaryExpressionTreeNode node)
        {
            node.Left!.AryNodeAccept(this);
            Inorder.Append(" ");
            Inorder.Append(node.Text);
            Inorder.Append(" ");
            node.Right!.AryNodeAccept(this);
        }
    }
}
