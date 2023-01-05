using Contracts;
using State_Machine;
using UnityEngine;

namespace Cat_States
{
    public class HuntingState 
        : CatState
    {
        public HuntingState(StateObjectBehavior stateObjectBehavior) 
            : base(stateObjectBehavior)
        { }
        
        public override void Enter()
        {
            SetStatus($"Cat is started hunting");
            StateObject.NavMeshAgent.autoBraking = false;
            StateObject.NavMeshAgent.isStopped = false;
            StateObject.NavMeshAgent.speed = 7.5f;
#if DEBUG
            Debug.Log($"Cat is started hunting");
#endif
        }

        public override IState LogicUpdate()
        {
            var rat = SceneData.Instance.Rat;
            var ratState = SceneData.Instance.Rat.StateMachine as RatStateMachine;
            
            StateObject.NavMeshAgent.destination = rat.transform.position;
            
            if (Vector3.Distance(rat.transform.position, StateObject.transform.position) < 1f) 
                ratState.TakeDamage();
            
#if DEBUG
            Debug.Log($"Cat is hunting"); 
#endif
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
            Debug.Log($"Cat is stopped to hunting");
#endif
        }
    }
}