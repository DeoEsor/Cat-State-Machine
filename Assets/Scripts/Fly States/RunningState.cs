using Contracts;
using State_Machine;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Fly_States
{
    public class RunningState : FlyState
    {
        public RunningState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Fly is started running");
            var player = SceneData.Instance.Player;
            var fly = StateObject;
            var vector = -(player.transform.position - fly.transform.position) * 10;
            StateObject.NavMeshAgent.destination = fly.transform.position + vector;
            StateObject.NavMeshAgent.isStopped = false;
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Running" + new string('.',Random.Range(0,3)));
            return this;
        }

        public override IState PhysicsUpdate()
        {
            SetStatus($"Fly is running");
            return base.PhysicsUpdate();
        }

        public override void Exit()
        {
            SetStatus($"Fly is run away");
            StateObject.NavMeshAgent.isStopped = true;
            StateObject.NavMeshAgent.destination = StateObject.transform.position;
        }
    }
}