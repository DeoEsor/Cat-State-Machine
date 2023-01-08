using Contracts;
using State_Machine;
using UnityEngine;

namespace Fly_States
{
    public class RoundingMoveState 
        : FlyState
    {
        public RoundingMoveState(StateObjectBehavior stateObject) 
            : base(stateObject)
        { }

        private GameObject player;
        
        public override void Enter()
        {
            SetStatus($"Fly is started rounding moving");
            base.Enter();
            player = SceneData.Instance.Player;
        }
        
        

        public override IState LogicUpdate()
        {
            
            StateObject.transform.RotateAround(player.transform.position, new Vector3(0, 3, 0), 100 * Time.deltaTime);
            StateObject.transform.LookAt(player.transform);

            return this;
        }

        public override void Exit()
        {
            SetStatus($"Fly is finished  random moving");
        }
    }
}