using System;
using State_Machine;

namespace Cat_States
{
    public sealed class CatStateMachine : StateMachine
    {
        public override void CheckAndChangeState(StateObjectBehavior stateObject)
        {
            throw new NotImplementedException();
        }

        public override void OnTriggered(string triggerKey)
        {
            throw new NotImplementedException();
        }
    }
}