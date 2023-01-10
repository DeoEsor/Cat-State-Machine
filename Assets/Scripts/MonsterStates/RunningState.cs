using Contracts;
using State_Machine;
using UnityEngine;

namespace MonsterStates
{
    public class RunningState : MonsterState
    {
        public RunningState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Monster is running");
            StateObject.NavMeshAgent.speed = 5;
            StateObject.NavMeshAgent.destination = SceneData.Instance.spawn.position;
            StateObject.NavMeshAgent.isStopped = false;
            base.Enter();
        }

        public override IState LogicUpdate()
        {   
            return this;
        }

        public override void Exit()
        {
            StateObject.NavMeshAgent.speed = 3;
            StateObject.NavMeshAgent.isStopped = true;
        }
    }
}