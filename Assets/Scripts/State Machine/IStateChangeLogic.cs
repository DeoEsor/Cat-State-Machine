namespace State_Machine
{
    public interface IStateChangeLogic
    {
        void CheckAndChangeState(IStateObject stateObject);
    }
}