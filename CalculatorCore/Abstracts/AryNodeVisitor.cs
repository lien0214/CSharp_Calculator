using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore.Abstracts
{
    internal abstract class AryNodeVisitor
    {
        public abstract void Visit(NullaryExpressionTreeNode node);
        public abstract void Visit(UnaryExpressionTreeNode node);
        public abstract void Visit(BinaryExpressionTreeNode node);
    }
}
