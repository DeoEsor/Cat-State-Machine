namespace State_Machine
{
    public interface IStateObject
    {   
        IStateMachine StateMachine { get; }
    }
}