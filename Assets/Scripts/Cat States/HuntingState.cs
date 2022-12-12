using State_Machine;

namespace Cat_States
{
    public class HuntingState : CatState
    {
        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override IState LogicUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override IState PhysicsUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }

        public HuntingState(StateObjectBehavior stateObjectBehavior, int layerMask) : base(stateObjectBehavior, layerMask)
        {
        }
    }
}