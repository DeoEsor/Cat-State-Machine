using Contracts;
using State_Machine;
using UnityEngine;

namespace Fly_States
{
    public class HuntingState 
        : FlyState
    {
        public HuntingState(StateObjectBehavior stateObjectBehavior) 
            : base(stateObjectBehavior)
        { }
        
        public override void Enter()
        {
            SetStatus($"Fly is started hunting");
            StateObject.NavMeshAgent.autoBraking = false;
            StateObject.NavMeshAgent.isStopped = false;
            StateObject.NavMeshAgent.speed = 7.5f;
            
            StateObject.NavMeshAgent.destination = SceneData.Instance.EatPlace.position;
#if DEBUG
            Debug.Log($"Fly is started hunting");
#endif
        }

        public override IState LogicUpdate()
        {
            return this;
        }

        public override IState PhysicsUpdate()
        {
            
            return this;
        }

        public override void Exit()
        {
            StateObject.NavMeshAgent.isStopped = true;
            StateObject.NavMeshAgent.speed = 3f;
#if DEBUG
            Debug.Log($"Fly is stopped to hunting");
#endif
        }
    }
}