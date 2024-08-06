using CalculatorCore.Utils;
using CalculatorCore;
namespace CalculatorAPI.Models
{
    public class FormContext
    {
        public string Input { get; set; } = Constants.ZERO;
        public string Output { get; set; } = string.Empty;
        public FormContext() { }
        public FormContext(string input, string output)
        {
            Input = input;
            Output = output;
        }
    }
}
