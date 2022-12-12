using State_Machine;
using UnityEngine;

namespace Cat_States
{
    public abstract class CatState : State
    {
        public CatState(StateObjectBehavior stateObjectBehavior, int layerMask)
            :base(stateObjectBehavior)
        {
            this.layerMask = layerMask;
        }

        private readonly int layerMask;
        
        protected bool CheckMouseAround() =>
            Physics.CheckBox(
                StateObject.transform.position, 
                Vector3.one, 
                StateObject.transform.rotation,
                layerMask);
    }
}