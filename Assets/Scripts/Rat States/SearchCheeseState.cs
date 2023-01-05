using Contracts;
using State_Machine;
using Random = UnityEngine.Random;

namespace Rat_States
{
    public class SearchCheeseState 
        : RatState
    {
        public SearchCheeseState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Started search a cheese");
            StateObject.NavMeshAgent.destination = SceneData.Instance.cheese.transform.position;
            StateObject.NavMeshAgent.isStopped = false;
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Searching" + new string('.',Random.Range(0,3)));
            return this;
        }

        public override IState PhysicsUpdate()
        {
            SetStatus($"Rat is started eating");
            return base.PhysicsUpdate();
        }

        public override void Exit()
        {
            SetStatus($"Rat is started eating");
            StateObject.NavMeshAgent.isStopped = true;
        }
    }
}