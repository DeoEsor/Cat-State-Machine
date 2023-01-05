using Contracts;
using State_Machine;

namespace Rat_States
{
    public class DeathState : RatState
    {
        public DeathState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Rat is dead");
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            
            return this;
        }

        public override IState PhysicsUpdate()
        {
            return base.PhysicsUpdate();
        }

        public override void Exit()
        {
        }
    }
}