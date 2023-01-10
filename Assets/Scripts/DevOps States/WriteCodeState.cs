using Contracts;
using State_Machine;
using UnityEngine;

namespace DevOps_States
{
    public class WriteCodeState : DevOpsState
    {
        public WriteCodeState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Rat is started eating");
            base.Enter();
            
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Writing code" + new string('.', Random.Range(0, 3)));
            
            data.timeSpendWithoutMonitor += 0.01f;
            data.tired += 0.01f;
            data.readyOfPatch += 0.01f;
            return this;
        }

        public override void Exit()
        {
        }
    }
} 