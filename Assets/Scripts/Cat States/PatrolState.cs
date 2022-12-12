using System.Collections.Generic;
using State_Machine;
using UnityEngine;

namespace Cat_States
{
    public class PatrolState : CatState
    {
        private int destPoint = 0; 
        
        private readonly List<Transform> PatrolPoints;

        public PatrolState(StateObjectBehavior stateObjectBehavior, int layerMask, List<Transform> patrolPoints) 
            : base(stateObjectBehavior, layerMask)
        {
            PatrolPoints = patrolPoints;
            StateObject.NavMeshAgent.autoBraking = false;
        }

        public override void Enter()
        {
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
            if (CheckMouseAround()) ;
            //StateObject.StateMachine.Trigger
            return this;
        }

        public override void Exit()
        {
            StateObject.NavMeshAgent.isStopped = true;
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