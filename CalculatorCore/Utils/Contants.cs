namespace CalculatorCore.Utils
{
    public static class Constants
    {
        public const string ZERO = "0";
        public const string DOT = ".";
        public const string ZERO_DOT = "0.";
        public const char EQUAL = '=';
        public const char PLUS = '+';
        public const char MINUS = '-';
        public const char MULTIPLY = '×';
        public const char DIVIDE = '÷';
        public const char POWER = '^';
        public const char MOD = '%';
        public const char SQUARE_ROOT = '√';
        public const char BACKSPACE = '←';
        public const char NEGATE = '±';
        public const char LEFT_PARENTHESIS = '(';
        public const char RIGHT_PARENTHESIS = ')';
        public const char DEFAULT_OPERATOR = ' ';
        public const string DIVISION_ERROR = "DIVISION ERROR";
        public const string SQUARE_ROOT_ERROR = "SQUARE ROOT OUT OF RANGE ERROR";

        public static bool IsAdditive(char op)
        {
            return op == PLUS || op == MINUS;
        }
        public static bool IsMultiplicative(char op)
        {
            return op == MULTIPLY || op == DIVIDE;
        }
    }
}
