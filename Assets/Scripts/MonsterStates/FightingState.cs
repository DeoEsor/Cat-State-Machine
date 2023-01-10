using Contracts;
using State_Machine;
using UnityEngine;

namespace MonsterStates
{
    public class FightingState : MonsterState
    {
        public FightingState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }
        
        public override void Enter()
        {
            SetStatus($"Monster is fighting");
            base.Enter();
        }

        public override IState LogicUpdate()
        {
            if (Random.Range(0, 1) == 1)
                SceneData.Instance.player.hp -= 20;
            else
                SceneData.Instance.monster.hp -= 20;
            return this;
        }

        public override void Exit()
        {
            StateObject.NavMeshAgent.speed = 4;
            StateObject.NavMeshAgent.isStopped = true;
        }
    }
}