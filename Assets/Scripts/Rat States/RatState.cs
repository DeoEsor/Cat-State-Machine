using Contracts;
using State_Machine;
using UnityEngine;

namespace Rat_States
{
    public abstract class RatState : State
    {
        protected RatState(StateObjectBehavior stateObject) 
            : base(stateObject)
        {
        }

        public override void Enter()
        {
            timeSpandInState = 0;
        }

        
    }
}