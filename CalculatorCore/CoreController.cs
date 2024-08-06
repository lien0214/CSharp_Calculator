using CalculatorCore.Interfaces;
using CalculatorCore.Utils;
namespace CalculatorCore
{
    public partial class CoreController
    {
        internal CoreContext Context { get; private set; }
        internal IState State { get => Context.State; private set => Context.State = value; }

        public void TransitionTo(StateType stateType) => State = Maps.StateMap[stateType];

        public CoreController()
        {
            Context = new CoreContext();
        }

        internal UIContext PackContext()
        {
            bool isNotError = State != Maps.StateMap[StateType.ErrorState];
            return new(Context.Input, Context.Output, Context.Prefix(), Context.Infix(), Context.Postfix(), isNotError);
        }
    }
}