using Contracts;
using State_Machine;
using UnityEngine;

namespace Hercules_States
{
    public class RollingBallState : HerculesState
    {
        public RollingBallState(StateObjectBehavior stateObject) 
            : base(stateObject)
        {}

        public override void Enter()
        {
            base.Enter();
            SceneData.Instance.CurrentBall.IsRolling = true;
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Hercules is rolling " + new string('z', Random.Range(0, 3)) );
            return this;
        }

        public override void Exit()
        {
            SceneData.Instance.CurrentBall.IsRolling = false;
        }
    }
}