using Contracts;
using State_Machine;
using UnityEngine;

namespace Rat_States
{
    public class EatingState : RatState
    {
        public EatingState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Rat is started eating");
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Rat is eating" + new string('.', Random.Range(0, 3)));
            return this;
        }

        public override IState PhysicsUpdate()
        {
            return base.PhysicsUpdate();
        }

        public override void Exit()
        {
            SetStatus($"Rat is finish eating");
        }
    }
} 