using System.Collections.Generic;

namespace Contracts
{
    public interface IStateMachine
    {
        IState State { get;  }
        
        public Dictionary<string, IState> States { get; }
        
        
        IStateMachine Initialize(IState state);
        
        void CheckAndChangeState();
    }
}