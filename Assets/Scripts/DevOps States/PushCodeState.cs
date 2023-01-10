using Contracts;
using State_Machine;
using Random = UnityEngine.Random;

namespace DevOps_States
{
    public class PushCodeState : DevOpsState
    {
        public PushCodeState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            StateObject.NavMeshAgent.destination = SceneData.Instance.monitor.transform.position;
            StateObject.NavMeshAgent.isStopped = false;
            
            data.readyOfPatch = 0;
            data.procentageOfWreckedCode = 0;
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Deploying" + new string('.',Random.Range(0,3)));
            
            data.timeSpendWithoutMonitor += 0.01f;
            data.tired += 0.01f;
            data.clientAngry += 0.01f;
            return this;
        }

        public override void Exit()
        {
            StateObject.NavMeshAgent.isStopped = true;
        }
    }
}