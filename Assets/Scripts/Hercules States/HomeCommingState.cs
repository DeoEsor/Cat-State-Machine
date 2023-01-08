using Contracts;
using State_Machine;
using UnityEngine;

namespace Hercules_States
{
    public class HomeCommingState 
        : HerculesState
    {
        public HomeCommingState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Hercules is started homecomming");
            StateObject.NavMeshAgent.speed = 7;
            StateObject.NavMeshAgent.destination = SceneData.Instance.Home.position;
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
            SetStatus($"Hercules is finished homecomming");
        }
    }
}