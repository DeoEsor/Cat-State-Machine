using System;
using Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace State_Machine
{
    [RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
    public sealed class StateObjectBehavior : MonoBehaviour, IStateObject
    {
        public IStateMachine StateMachine { get; private set; }
        
        public Animator Animator { get; set; }
        
        public NavMeshAgent NavMeshAgent { get; set; }

        public TMP_Text text;

        public StateMachineType Type;

        private void Awake()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
        }

        private void Start()
        {
            switch (Type)
            {
                case StateMachineType.Cat:
                    StateMachine = new CatStateMachine(SceneData.Instance.layerMask, this);
                    StateMachine.Initialize(StateMachine.States["Patrol"]);
                    break;
                case StateMachineType.Rat:
                    StateMachine = new RatStateMachine(this);
                    StateMachine.Initialize(StateMachine.States["Search Cheese"]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Update()
        {
            StateMachine.State
                .LogicUpdate()
                .HandleInput();
            
            StateMachine.CheckAndChangeState();
        }

        private void LateUpdate()
        {
            StateMachine.State.PhysicsUpdate();
        }
    }
}