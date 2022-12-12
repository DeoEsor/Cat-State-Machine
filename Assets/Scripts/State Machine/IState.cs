using UnityEngine;

namespace State_Machine
{
    public interface IState
    {
        public abstract string Name { get; }
        StateObjectBehavior StateObject { get; set; }
        
        public void Enter();

        public IState HandleInput();

        public IState LogicUpdate();

        public IState PhysicsUpdate();

        public void Exit();
    }
}