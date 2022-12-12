namespace State_Machine
{
    public abstract class State :  IState
    {
        public StateObjectBehavior StateObject { get; set; }
        public abstract void Enter();

        public virtual IState HandleInput() => this;

        public abstract IState LogicUpdate();
        
        public abstract IState PhysicsUpdate();
        
        public abstract void Exit();
    }
}