using State_Machine;

namespace Contracts
{
    public interface IState
    {
        StateObjectBehavior StateObject { get; set; }
        
        public void Enter();

        public IState HandleInput();

        public IState LogicUpdate();

        public IState PhysicsUpdate();

        public void Exit();
    }
}