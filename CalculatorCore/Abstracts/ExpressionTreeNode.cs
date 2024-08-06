namespace CalculatorCore.Abstracts
{
    internal abstract class ExpressionTreeNode
    {
        /// <summary>
        /// Text Formula is for Dynamic Programming later
        /// </summary>
        public string TextFormula { get; set; }
        public int Index { get; set; }
        private static int indexCounter = 0;
        public string Text { get; set; }
        public decimal Value { get; set; }
        public ExpressionTreeNode(string textFormula, string text, decimal value)
        {
            TextFormula = textFormula;
            Text = text;
            Value = value;
            Index = indexCounter++;
        }
        public ExpressionTreeNode(string text, decimal value) : this(string.Empty, text, value) { }
        public ExpressionTreeNode(string text) : this(string.Empty, text, 0) { }

        public abstract void RealNodeAccept(RealNodeVisitor visitor);
        public abstract void AryNodeAccept(AryNodeVisitor visitor);
    }
}   
