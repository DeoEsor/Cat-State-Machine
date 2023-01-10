using Contracts;
using State_Machine;
using UnityEngine;

namespace DevOps_States
{
    public class WatchMonitoringState : DevOpsState
    {
        public WatchMonitoringState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            StateObject.NavMeshAgent.speed = 7;
            StateObject.NavMeshAgent.destination = SceneData.Instance.monitor.position;
            StateObject.NavMeshAgent.isStopped = false;
            
            data.timeSpendWithoutMonitor = 0;
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Watching metrics" + new string('.',Random.Range(0,3)));
            data.tired += 0.01f;
            data.procentageOfWreckedCode += 0.01f;
            return this;
        }

        public override void Exit()
        {
            StateObject.NavMeshAgent.speed = 4;
            StateObject.NavMeshAgent.isStopped = true;
            SetStatus($"Rat is finished running");
        }
    }
}