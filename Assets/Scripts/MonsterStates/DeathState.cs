using Contracts;
using State_Machine;
using UnityEngine;

namespace MonsterStates
{
    public class DeathState : MonsterState
    {
        public DeathState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Monster is dead");
            base.Enter();
        }

        public override IState LogicUpdate() => this;

        public override void Exit()
        {}
    }
}