using Contracts;
using State_Machine;
using UnityEngine;

namespace Hercules_States
{
    public class SleepState : HerculesState
    {
        public SleepState(StateObjectBehavior stateObjectBehavior) 
            : base(stateObjectBehavior)
        {}

        public override IState LogicUpdate()
        {
            SetStatus($"Hercules is sleeping " + new string('z', Random.Range(0, 3)) );
            return this;
        }

        public override void Exit()
        {}
    }
}