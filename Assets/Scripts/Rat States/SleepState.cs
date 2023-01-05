using Contracts;
using State_Machine;
using UnityEngine;

namespace Rat_States
{
    public class SleepState : RatState
    {
        private static readonly int StateName = Animator.StringToHash("sleep_state");

        private string[] ideas = { "Mouse", "Milk", "Cat" };

        public SleepState(StateObjectBehavior stateObjectBehavior) 
            : base(stateObjectBehavior)
        {
        }

        public override void Enter()
        {
            SetStatus($"Rat is falling a sleep and thinking about {ideas[Random.Range(0, ideas.Length)]}");
            StateObject.Animator.SetBool(StateName, true);
            
#if DEBUG
            Debug.Log($"Rat is falling a sleep");
#endif
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Rat is sleeping " + new string('z', Random.Range(0, 3)) );
#if DEBUG
            Debug.Log($"Rat: thinking about {ideas[Random.Range(0, ideas.Length)]}");
#endif
            return this;
        }

        public override IState PhysicsUpdate()
        {
            return this;
        }

        public override void Exit()
        {
            StateObject.Animator.SetBool(StateName, false);
#if DEBUG
            Debug.Log($"Rat is rise up");
#endif
        }
    }
}