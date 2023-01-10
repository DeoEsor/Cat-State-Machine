using System;
using Contracts;
using State_Machine;
using Random = UnityEngine.Random;

namespace DevOps_States
{
    public class SleepState : DevOpsState
    {

        public SleepState(StateObjectBehavior stateObjectBehavior) 
            : base(stateObjectBehavior)
        {
        }

        public override void Enter()
        {
            StateObject.NavMeshAgent.destination = SceneData.Instance.bad.transform.position;
            StateObject.NavMeshAgent.isStopped = false;
            data.tired = 0;
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Sleeping" + new string('.',Random.Range(0,3)));
            data.timeSpendWithoutMonitor += 0.01f;
            data.clientAngry += 0.002f;
            return this;
        }

        public override void Exit()
        {
            SetStatus(String.Empty);
            StateObject.NavMeshAgent.isStopped = true;
        }
    }
}