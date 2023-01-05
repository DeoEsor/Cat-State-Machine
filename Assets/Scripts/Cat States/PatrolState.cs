using System.Collections.Generic;
using Contracts;
using State_Machine;
using UnityEngine;

namespace Cat_States
{
    public class PatrolState : CatState
    {
        private int destPoint; 
        
        private readonly List<Transform> PatrolPoints;

        public PatrolState(StateObjectBehavior stateObjectBehavior, List<Transform> patrolPoints) 
            : base(stateObjectBehavior)
        {
            PatrolPoints = patrolPoints;
            StateObject.NavMeshAgent.autoBraking = false;
        }

        public override void Enter()
        {
            SetStatus($"Cat is started a patrol");
#if DEBUG
            Debug.Log($"Cat is started a patrol");
#endif
            StateObject.NavMeshAgent.isStopped = false;
        }

        public override IState LogicUpdate()
        {
            if (!StateObject.NavMeshAgent.pathPending && StateObject.NavMeshAgent.remainingDistance < 0.5f)
                GotoNextPoint();

            return this;
        }

        public override IState PhysicsUpdate()
        {
            return this;
        }

        public override void Exit()
        {
            StateObject.NavMeshAgent.isStopped = true;
            
#if DEBUG
            Debug.Log($"Cat is stopped a patrolling");
#endif
        }

        private void GotoNextPoint() 
        {
            if (PatrolPoints.Count == 0)
                return;

            StateObject.NavMeshAgent.destination = PatrolPoints[destPoint].position;
            
            destPoint = (destPoint + 1) % PatrolPoints.Count;
        }

    }
}