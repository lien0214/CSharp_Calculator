namespace CalculatorCore.Utils
{
    public static class StringHandling
    {
        public static decimal StringtoDecimal(string input)
        {
            string ret = input.Contains(Constants.DOT)
                ? input.TrimEnd(char.Parse(Constants.ZERO)).TrimEnd(char.Parse(Constants.DOT))
                : input;
            return MathHandling.Round(decimal.Parse(ret));
        }
        
        public static string AppendDigit(string input, char digit)
        {
            return string.Equals(input, Constants.ZERO) ? $"{digit}" : $"{input}{digit}";
        }

        public static string AppendDigit(string input, string digit) => AppendDigit(input, digit[0]);
        public static string AppendDot(string input)
        {
            return input.Contains(Constants.DOT) ? input : $"{input}{Constants.DOT}";
        }

        public static string AppendDigitDot(string input, string digit) => AppendDigitDot(input, digit[0]);
        public static string AppendDigitDot(string input, char digit)
        {
            return digit.ToString() == Constants.DOT ? AppendDot(input) : AppendDigit(input, digit);
        }

        public static string AppendNegative(string input)
        {
            if(input == Constants.ZERO)
            {
                return input;
            }
            return input[0] == Constants.MINUS ? input[1..] : $"{Constants.MINUS}{input}";
        }

        public static string Backspace(string input)
        {
            return input.Length > 1 ? input[..^1] : Constants.ZERO;
        }
    }
}
