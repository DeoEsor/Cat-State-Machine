using Contracts;
using TMPro;
using UnityEngine;

namespace State_Machine
{
    public abstract class State 
        : IState
    {
        public float timeSpandInState = 0;
        
        private TMP_Text _text;
        
        protected State(StateObjectBehavior stateObject)
        {
            StateObject = stateObject;
            _text = StateObject.text;
        }
        
        public StateObjectBehavior StateObject { get; set; }
        
        public abstract void Enter();

        public virtual IState HandleInput() => this;

        public abstract IState LogicUpdate();

        public virtual IState PhysicsUpdate()
        {
            timeSpandInState += Time.deltaTime;
            return this;
        }
        
        public abstract void Exit();

        protected void SetStatus(string s)
        {
            _text.enabled = true;
            _text.text = s;
        }
    }
}