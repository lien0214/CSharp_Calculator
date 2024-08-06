using CalculatorCore.Utils;
namespace CalculatorCore
{
    public class UIContext
    {
        public string Input { get; set; } = Constants.ZERO;
        public string Output { get; set; } = string.Empty;
        public string Preorder { get; set; } = string.Empty;
        public string Inorder { get; set; } = string.Empty;
        public string Postfix { get; set; } = string.Empty;

        public Dictionary<string, bool> Enables { get; set; } = new();
        public UIContext() { }
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
