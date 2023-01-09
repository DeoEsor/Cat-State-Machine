using Contracts;
using State_Machine;
using UnityEngine;

namespace Cat_States
{
    public class EatingState 
        : CatState
    {
        public EatingState(StateObjectBehavior stateObjectBehavior) 
            : base(stateObjectBehavior)
        { }
        
        public override void Enter()
        {
            timeSpandInState = 0;
            SetStatus("Cat is started eating");
#if DEBUG
            Debug.Log($"Cat is started eating");
#endif
        }

        public override IState LogicUpdate()
        {
            SetStatus("Cat is eating");
            return this;
        }

        public override void Exit()
        {
            SetStatus("Cat is stopped eat");
#if DEBUG
            Debug.Log($"Cat is stopped eat");
#endif
        }
    }
} 