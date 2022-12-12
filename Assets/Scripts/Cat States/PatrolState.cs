using System.Collections.Generic;
using State_Machine;
using UnityEngine;

namespace Cat_States
{
    public class PatrolState : CatState
    {
        private List<Transform> PatrolPoints = new List<Transform>();
        
        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override IState LogicUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override IState PhysicsUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}