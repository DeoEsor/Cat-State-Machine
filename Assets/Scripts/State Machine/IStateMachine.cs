namespace State_Machine
{
    public interface IStateMachine
    {
        IState State { get;  }
        
        IStateMachine Initialize(IState state);
        
        void CheckAndChangeState(StateObjectBehavior stateObject);
    }
}