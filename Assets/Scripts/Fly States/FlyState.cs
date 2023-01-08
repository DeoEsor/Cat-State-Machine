using State_Machine;

namespace Fly_States
{
    public abstract class FlyState : State
    {
        protected FlyState(StateObjectBehavior stateObject) 
            : base(stateObject)
        {
        }

        public override void Enter()
        {
            timeSpandInState = 0;
        }
    }
}