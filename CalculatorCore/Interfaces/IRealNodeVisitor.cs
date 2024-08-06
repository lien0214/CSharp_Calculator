using CalculatorCore.ExpressionTreeNodes.RealTreeNodes;

namespace CalculatorCore.Interfaces
{
    internal interface IRealNodeVisitor
    {
        /// <summary>
        /// Visits an OperatorTreeNode.
        /// </summary>
        /// <param name="node">The OperatorTreeNode to visit.</param>
        void Visit(OperatorTreeNode node);

        /// <summary>
        /// Visits an EqualTreeNode.
        /// </summary>
        /// <param name="node">The EqualTreeNode to visit.</param>
        void Visit(EqualTreeNode node);

        /// <summary>
        /// Visits a ParenthesesTreeNode.
        /// </summary>
        /// <param name="node">The ParenthesesTreeNode to visit.</param>
        void Visit(ParenthesesTreeNode node);

        /// <summary>
        /// Visits a SquareRootTreeNode.
        /// </summary>
        /// <param name="node">The SquareRootTreeNode to visit.</param>
        void Visit(SquareRootTreeNode node);

        /// <summary>
        /// Visits a NegateTreeNode.
        /// </summary>
        /// <param name="node">The NegateTreeNode to visit.</param>
        void Visit(NegateTreeNode node);

        /// <summary>
        /// Visits a NumberTreeNode.
        /// </summary>
        /// <param name="node">The NumberTreeNode to visit.</param>
        void Visit(NumberTreeNode node);
    }
}
