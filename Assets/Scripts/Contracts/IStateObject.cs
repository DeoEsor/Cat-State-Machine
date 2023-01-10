namespace Contracts
{
    public interface IStateObject
    {   
        IStateMachine StateMachine { get; }
    }
}