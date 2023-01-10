using Contracts;
using State_Machine;
using UnityEngine;

namespace MonsterStates
{
    public class EatingState : MonsterState
    {
        public EatingState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }

        public override IState LogicUpdate()
        {
            SetStatus($"Monster is eating" + new string('.', Random.Range(0, 3)));
            return this;
        }

        public override void Exit()
        {
        }
    }
} 