using CalculatorCore.Utils;
namespace CalculatorCore
{
    public class UIContext
    {
        public string Input { get; set; } = Constants.ZERO;
        public string Output { get; set; } = string.Empty;
        public string Prefix { get; set; } = string.Empty;
        public string Infix { get; set; } = string.Empty;
        public string Postfix { get; set; } = string.Empty;

        public Dictionary<string, bool> Enables { get; set; } = new();
        public UIContext() { }
        internal UIContext(string input, string output, string prefix, string infix, string postfix, bool isNotError)
        {
            Input = input;
            Output = output;
            Prefix = prefix;
            Infix = infix;
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
