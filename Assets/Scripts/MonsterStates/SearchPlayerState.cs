using Contracts;
using State_Machine;
using Random = UnityEngine.Random;

namespace MonsterStates
{
    public class SearchPlayerState 
        : MonsterState
    {
        public SearchPlayerState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            StateObject.NavMeshAgent.destination = SceneData.Instance.player.transform.position;
            StateObject.NavMeshAgent.speed = 2;
            StateObject.NavMeshAgent.isStopped = false;
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Searching" + new string('.',Random.Range(0,3)));
            StateObject.NavMeshAgent.destination = SceneData.Instance.player.transform.position;
            return this;
        }

        public override void Exit()
        {
            StateObject.NavMeshAgent.speed = 3;
            StateObject.NavMeshAgent.isStopped = true;
        }
    }
}