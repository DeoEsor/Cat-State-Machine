using State_Machine;

namespace Rat_States
{
    public abstract class RatState : State
    {
        protected RatState(StateObjectBehavior stateObject) : base(stateObject)
        {
        }
    }
}