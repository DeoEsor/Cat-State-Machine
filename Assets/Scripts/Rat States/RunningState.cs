using Contracts;
using State_Machine;
using UnityEngine;

namespace Rat_States
{
    public class RunningState 
        : RatState
    {
        public RunningState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Rat is started running");
            StateObject.NavMeshAgent.speed = 7;
            StateObject.NavMeshAgent.destination = SceneData.Instance.holes[Random.Range(0, SceneData.Instance.holes.Count)].position;
            StateObject.NavMeshAgent.isStopped = false;
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            
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