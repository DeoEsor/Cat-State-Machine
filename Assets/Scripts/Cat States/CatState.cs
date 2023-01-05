using State_Machine;
using UnityEngine;

namespace Cat_States
{
    public abstract class CatState 
        : State
    {
        public CatState(StateObjectBehavior stateObjectBehavior)
            :base(stateObjectBehavior)
        {
        }
    }
}