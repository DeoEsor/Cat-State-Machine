using Contracts;
using State_Machine;
using UnityEngine;

namespace Hercules_States
{
    public class SittingState: HerculesState
    {
        public SittingState(StateObjectBehavior stateObject) 
            : base(stateObject)
        {}

        public override void Enter()
        {
            base.Enter();
            StateObject.transform.position = SceneData.Instance.CurrentBall.transform.position + Vector3.up * 2;
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Hercules is sitting" + new string('.', Random.Range(0, 3)) );
            return this;
        }

        public override void Exit()
        {
            StateObject.transform.position = SceneData.Instance.CurrentBall.transform.position + Vector3.left * 3;
        }
    }
}