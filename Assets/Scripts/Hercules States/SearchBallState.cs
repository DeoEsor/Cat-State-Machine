using Contracts;
using State_Machine;
using UnityEngine;

namespace Hercules_States
{
    public class SearchBallState 
        : HerculesState
    {
        public SearchBallState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Started search a ball");
            SceneData.Instance.CurrentBall = SceneData.Instance.Balls[Random.Range(0, SceneData.Instance.Balls.Count)];
            StateObject.NavMeshAgent.destination = SceneData.Instance.CurrentBall.transform.position;
            StateObject.NavMeshAgent.isStopped = false;
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Searching" + new string('.',Random.Range(0,3)));
            return this;
        }


        public override void Exit()
        {
            SetStatus($"Hercules has finded ball");
            StateObject.NavMeshAgent.isStopped = true;
        }
    }
}