using Contracts;
using State_Machine;
using UnityEngine;

namespace Fly_States
{
    public class EatingState : FlyState
    {
        public EatingState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Fly is started eating");
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Fly is eating" + new string('.', Random.Range(0, 3)));
            return this;
        }

        public override void Exit()
        {
            SetStatus($"Fly is finish eating");
        }
    }
}