using CalculatorCore.Utils;
namespace CalculatorCore
{
    /// <summary>
    /// Represents the context of the user interface.
    /// </summary>
    public class UIContext
    {
        /// <summary>
        /// Gets or sets the current input string of the calculator. Default is "0".
        /// </summary>
        public string Input { get; set; } = Constants.ZERO;

        /// <summary>
        /// Gets or sets the current output string of the calculator. Default is an empty string.
        /// </summary>
        public string Output { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the preorder notation of the current expression. Default is an empty string.
        /// </summary>
        public string Preorder { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the inorder notation of the current expression. Default is an empty string.
        /// </summary>
        public string Inorder { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the postfix notation of the current expression. Default is an empty string.
        /// </summary>
        public string Postfix { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a dictionary indicating whether each calculator button is enabled.
        /// </summary>
        public Dictionary<string, bool> Enables { get; set; } = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="UIContext"/> class with default values.
        /// </summary>
        public UIContext() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIContext"/> class with specified values.
        /// </summary>
        /// <param name="input">The initial input string.</param>
        /// <param name="output">The initial output string.</param>
        /// <param name="preorder">The initial preorder notation string.</param>
        /// <param name="inorder">The initial inorder notation string.</param>
        /// <param name="postfix">The initial postfix notation string.</param>
        /// <param name="isNotError">Indicates whether the initial state is not an error.</param>
        internal UIContext(string input, string output, string preorder, string inorder, string postfix, bool isNotError)
        {
            Input = input;
            Output = output;
            Preorder = preorder;
            Inorder = inorder;
            Postfix = postfix;
            Enables["+"] = isNotError;
            Enables["-"] = isNotError;
            Enables["×"] = isNotError;
            Enables["÷"] = isNotError;
            Enables["^"] = isNotError;
            Enables["%"] = isNotError;
            Enables["("] = isNotError;
            Enables[")"] = isNotError;
            Enables["."] = isNotError;
            Enables["±"] = isNotError;
            Enables["√"] = isNotError;
            Enables["0"] = true;
            Enables["1"] = true;
            Enables["2"] = true;
            Enables["3"] = true;
            Enables["4"] = true;
            Enables["5"] = true;
            Enables["6"] = true;
            Enables["7"] = true;
            Enables["8"] = true;
            Enables["9"] = true;
            Enables["C"] = true;
            Enables["CE"] = true;
            Enables["←"] = true;
            Enables["="] = true;
        }
    }
}
