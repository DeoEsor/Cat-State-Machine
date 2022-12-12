namespace State_Machine
{
    public abstract class StateMachine : IStateMachine
    {
        public string Name { get; }
        
        public IState State { get; set; }
        
        public StateObjectBehavior StateObject { get; set; }

        public IStateMachine Initialize(IState state)
        {
            State.Exit();
            State = state;
            State.Enter();
            return this;
        }

        public abstract void CheckAndChangeState(StateObjectBehavior stateObject);

    }
}