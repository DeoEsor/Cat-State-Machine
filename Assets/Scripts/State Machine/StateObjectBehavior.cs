using UnityEngine;
using UnityEngine.AI;

namespace State_Machine
{
    [RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
    public class StateObjectBehavior : MonoBehaviour, IStateObject
    {
        public IStateMachine StateMachine { get; }
        
        public Animator Animator { get; set; }
        
        public NavMeshAgent NavMeshAgent { get; set; }

        protected virtual void Awake()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
        }

        protected virtual void Start()
        {
            
        }

        protected virtual void Update()
        {
            StateMachine.State
                .LogicUpdate()
                .HandleInput();
            
            StateMachine.CheckAndChangeState(this);
        }

        protected virtual void LateUpdate() => StateMachine.State.PhysicsUpdate();
    }
}