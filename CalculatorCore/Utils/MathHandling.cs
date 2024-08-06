using Microsoft.VisualBasic;
using System.Diagnostics;

namespace CalculatorCore.Utils
{
    public static class MathHandling
    {
        public static decimal Sqrt(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value", "Square root of a negative number is undefined.");
            }
            else if (value == 0 || value == 1)
            {
                return value;
            }
            decimal epsilon = 0.00000000000000000000000001M;
            decimal x = value;
            decimal root = value / 2;

            while (Math.Abs(root - x / root) > epsilon)
            {
                root = (root + x / root) / 2;
            }

            return Round(root);
        }
        public static decimal Calculate(decimal lhs, char op, decimal rhs)
        {
            return op switch
            {
                Constants.PLUS => lhs + rhs,
                Constants.MINUS => lhs - rhs,
                Constants.MULTIPLY => lhs * rhs,
                Constants.DIVIDE => lhs / rhs,
                Constants.MOD => lhs % rhs,
                Constants.POWER => (decimal)Math.Pow((double)lhs, (double)rhs),
                _ => throw new Exception("Invalid operator"),
            };
        }
        public static decimal Round(decimal value)
        {
            string valueString = value.ToString();
            if (valueString.Contains(Constants.DOT) is false) return value;
            string trimmedValue = value.ToString().TrimEnd('0').TrimEnd('.');
            return string.IsNullOrEmpty(trimmedValue) ? 0 : decimal.Parse(trimmedValue);
        }
    }
}
