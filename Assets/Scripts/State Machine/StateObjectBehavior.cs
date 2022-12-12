using System;
using UnityEngine;

namespace State_Machine
{
    public class StateObjectBehavior : MonoBehaviour, IStateObject
    {
        public IState StateMachine { get; set; }
        public IStateChangeLogic StateChangeLogic { get; }
        
        public Animator Animator { get; }

        protected virtual void Awake()
        {
            throw new NotImplementedException();
        }

        protected virtual void Start()
        {
            throw new NotImplementedException();
        }

        protected virtual void Update()
        {
            StateMachine.LogicUpdate()
                .HandleInput();
            
            StateChangeLogic.CheckAndChangeState(this);
        }

        protected void LateUpdate() => StateMachine.PhysicsUpdate();
    }
}