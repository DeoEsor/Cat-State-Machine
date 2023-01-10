using State_Machine;

namespace MonsterStates
{
    public abstract class MonsterState : State
    {
        protected MonsterState(StateObjectBehavior stateObject) 
            : base(stateObject)
        {
        }

        public override void Enter()
        {
            timeSpandInState = 0;
        }
    }
}