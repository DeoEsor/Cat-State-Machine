using State_Machine;

namespace Rat_States
{
    public abstract class RatState : IState
    {
        public string Name { get; }
        
        public StateObjectBehavior StateObject { get; set; }
        public abstract void Enter();
        public abstract IState HandleInput();
        public abstract IState LogicUpdate();
        public abstract IState PhysicsUpdate();
        public abstract void Exit();
    }
}