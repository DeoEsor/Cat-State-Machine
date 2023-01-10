using Contracts;
using State_Machine;
using UnityEngine;

namespace MonsterStates
{
    public class SleepState : MonsterState
    {
        public SleepState(StateObjectBehavior stateObjectBehavior) 
            : base(stateObjectBehavior)
        {
        }

        public override void Enter()
        {
            SetStatus($"Monster is sleeping");
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Monster is sleeping " + new string('z', Random.Range(0, 3)) );
            return this;
        }

        public override void Exit()
        {
        }
    }
}