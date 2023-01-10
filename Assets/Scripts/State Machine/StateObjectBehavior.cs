using System;
using System.Collections;
using Contracts;
using MonsterStates;
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

        public int hp = 100;
        public int lvl = 5;


        private void Awake()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
        }

        private void Start()
        {
            StateMachine = new MonsterStateMachine(this);
            StateMachine.Initialize(StateMachine.States[nameof(SearchPlayerState)]);
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

        public void ResetPosition()
        {
            StartCoroutine(SpawnDelay());
        }

        private IEnumerator SpawnDelay()
        {
            yield return new WaitForSeconds(2);
            var rat = SceneData.Instance.monster;
            
            rat.StateMachine.Initialize(rat.StateMachine.States["Sleep"]);
            rat.transform.position = SceneData.Instance.spawn.position;
        }
    }
}