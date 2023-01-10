using System;
using Contracts;
using State_Machine;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DevOps_States
{
    public class ClientTalkState : DevOpsState
    {
        public ClientTalkState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            StateObject.NavMeshAgent.destination = SceneData.Instance.client.transform.position;
            StateObject.NavMeshAgent.isStopped = false;
            base.Enter();
            data.clientAngry = 0;
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Talking with client" + new string('.',Random.Range(0,3)));
            
            data.timeSpendWithoutMonitor += 0.02f;
            data.tired += 0.01f;
            
            return this;
        }

        public override void Exit()
        {
            SetStatus(String.Empty);
            StateObject.NavMeshAgent.isStopped = true;
        }
    }
}