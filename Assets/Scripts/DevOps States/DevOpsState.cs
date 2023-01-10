using State_Machine;

namespace DevOps_States
{
    public abstract class DevOpsState : State
    {
        public SceneData data = SceneData.Instance;
        protected DevOpsState(StateObjectBehavior stateObject) 
            : base(stateObject)
        {
        }

        public override void Enter()
        {
            timeSpandInState = 0;
        }
    }
}