using Contracts;
using State_Machine;

namespace Rat_States
{
    public class SearchCheeseState 
        : RatState
    {
        public RunningState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Rat is started eating");
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Rat is started eating");
            return this;
        }

        public override IState PhysicsUpdate()
        {
            SetStatus($"Rat is started eating");
            return this;
        }

        public override void Exit()
        {
            SetStatus($"Rat is started eating");
        }
    }
}