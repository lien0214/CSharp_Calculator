using CalculatorCore.Abstracts;
using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using CalculatorCore.ExpressionTreeNodes.RealTreeNodes;
using CalculatorCore.Utils;
using System.Text;

namespace CalculatorCore.Visitors
{
    internal class TreeOutputVisitor : RealNodeVisitor
    {
        public override void Visit(OperatorTreeNode node)
        {
            if (node.TextFormula != string.Empty)
            {
                return;
            }
            node.Left!.RealNodeAccept(this);
            node.Right!.RealNodeAccept(this);
            node.TextFormula = $"{node.Left!.TextFormula}{node.Text}{node.Right!.TextFormula}";
        }

        public override void Visit(EqualTreeNode node)
        {
            if (node.TextFormula != string.Empty)
            {
                return;
            }
            node.Child!.RealNodeAccept(this);
            node.TextFormula = $"{node.Child!.TextFormula}{node.Text}";
        }

        public override void Visit(ParenthesesTreeNode node)
        {
            if (node.TextFormula != string.Empty)
            {
                return;
            }
            node.Child!.RealNodeAccept(this);
            node.TextFormula = $"{Constants.LEFT_PARENTHESIS}{node.Child!.TextFormula}{Constants.RIGHT_PARENTHESIS}";
        }

        public override void Visit(SquareRootTreeNode node)
        {
            if (node.TextFormula != string.Empty)
            {
                return;
            }
            node.Child!.RealNodeAccept(this);
            node.TextFormula = $"{Constants.SQUARE_ROOT}{Constants.LEFT_PARENTHESIS}{node.Child!.TextFormula}{Constants.RIGHT_PARENTHESIS}";
        }

        public override void Visit(NegateTreeNode node)
        {
            if (node.TextFormula != string.Empty)
            {
                return;
            }
            node.Child!.RealNodeAccept(this);
            node.TextFormula = $"{Constants.NEGATE}{Constants.LEFT_PARENTHESIS}{node.Child!.TextFormula}{Constants.RIGHT_PARENTHESIS}";
        }

        public override void Visit(NumberTreeNode node)
        {
            node.TextFormula = node.Text;
        }
    }
}
