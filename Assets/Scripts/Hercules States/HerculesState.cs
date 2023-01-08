using State_Machine;

namespace Hercules_States
{
    public abstract class HerculesState : State
    {
        protected HerculesState(StateObjectBehavior stateObject) 
            : base(stateObject)
        {
        }

        public override void Enter()
        {
            timeSpandInState = 0;
        }

        
    }
}