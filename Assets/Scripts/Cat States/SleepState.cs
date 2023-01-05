using Contracts;
using State_Machine;
using UnityEngine;

namespace Cat_States
{
    public class SleepState : CatState
    {
        private static readonly int StateName = Animator.StringToHash("sleep_state");

        private string[] ideas = { "Mouse", "Milk", "Cat" };

        public SleepState(StateObjectBehavior stateObjectBehavior) 
            : base(stateObjectBehavior)
        {
        }

        public override void Enter()
        {
            SetStatus($"Cat is falling a sleep and thinking about {ideas[Random.Range(0, ideas.Length)]}");
            StateObject.Animator.SetBool(StateName, true);
            
#if DEBUG
            Debug.Log($"Cat is falling a sleep");
#endif
        }

        public override IState LogicUpdate()
        {
            SetStatus($"Cat is sleeping " + new string('z', Random.Range(0, 3)) );
#if DEBUG
            Debug.Log($"Cat: thinking about {ideas[Random.Range(0, ideas.Length)]}");
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
            Debug.Log($"Cat is rise up");
#endif
        }
    }
}