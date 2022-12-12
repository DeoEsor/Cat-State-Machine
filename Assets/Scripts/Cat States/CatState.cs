using State_Machine;
using UnityEngine;

namespace Cat_States
{
    public abstract class CatState : IState
    {
        public string Name { get; }
        public StateObjectBehavior StateObject { get; set; }
        public abstract void Enter();

        public virtual IState HandleInput() => this;

        public abstract IState LogicUpdate();
        
        public abstract IState PhysicsUpdate();
        
        public abstract void Exit();
    }
}