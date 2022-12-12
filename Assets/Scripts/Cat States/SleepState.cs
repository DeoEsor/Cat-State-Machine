using State_Machine;
using TMPro;
using UnityEngine;

namespace Cat_States
{
    public class SleepState : CatState
    {
        public TMP_Text text;
        private static readonly int StateName = Animator.StringToHash("sleep_state");
        public LayerMask layerMask;

        private string[] ideas = { "Mouse", "Milk", "Cat" };

        public override void Enter()
        {
            text.enabled = true;
            StateObject.Animator.SetBool(StateName, true);
            
        }

        public override IState LogicUpdate()
        {
#if DEBUG
            Debug.Log($"Cat: thinking about {ideas[Random.Range(0, ideas.Length)]}");
            Debug.Log($"Cat is sleeping");
#endif
            
            return this;
        }

        public override IState PhysicsUpdate()
        {
            Physics.CheckBox(
                StateObject.transform.position, 
                Vector3.one, 
                Quaternion.identity, 
                layerMask);
            
            return this;
        }

        public override void Exit()
        {
            StateObject.Animator.SetBool(StateName, false);
        }
    }
}