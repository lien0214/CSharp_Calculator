using CalculatorCore.ExpressionTreeNodes.AryTreeNodes;

namespace CalculatorCore.Interfaces
{
    internal interface IAryNodeVisitor
    {
        /// <summary>
        /// Visits a NullaryExpressionTreeNode.
        /// </summary>
        /// <param name="node">The NullaryExpressionTreeNode to visit.</param>
        void Visit(NullaryExpressionTreeNode node);

        /// <summary>
        /// Visits a UnaryExpressionTreeNode.
        /// </summary>
        /// <param name="node">The UnaryExpressionTreeNode to visit.</param>
        void Visit(UnaryExpressionTreeNode node);

        /// <summary>
        /// Visits a BinaryExpressionTreeNode.
        /// </summary>
        /// <param name="node">The BinaryExpressionTreeNode to visit.</param>
        void Visit(BinaryExpressionTreeNode node);
    }
}
