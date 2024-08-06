using CalculatorCore.Interfaces;
using CalculatorCore.States;
using System.Runtime.CompilerServices;

namespace CalculatorCore.Utils
{
    /// <summary>
    /// Enumeration of possible states for the calculator context.
    /// </summary>
    public enum StateType
    {
        InitialState,
        NumberState,
        BinaryOperationState,
        UnaryOperationState,
        EqualState,
        ErrorState,
    }
    internal static class Maps
    {
        public static readonly Dictionary<StateType, IState> StateMap = new()
        {
            { StateType.InitialState, new InitialState()},
            { StateType.NumberState, new NumberState() },
            { StateType.BinaryOperationState, new BinaryOperationState() },
            { StateType.UnaryOperationState, new UnaryOperationState() },
            { StateType.EqualState, new EqualState() },
            { StateType.ErrorState, new ErrorState() },
        };
    }
}
