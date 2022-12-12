namespace State_Machine
{
    public interface IStateObject
    {
        IState StateMachine { get; set; }
        
        IStateChangeLogic StateChangeLogic { get; }
    }
}