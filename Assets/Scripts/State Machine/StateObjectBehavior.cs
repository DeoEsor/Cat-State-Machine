﻿using System;
using Contracts;
using DevOps_States;
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

        private void Awake()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
        }

        private void Start()
        {
            StateMachine = new DevOpsStateMachine(this);
            StateMachine.Initialize(StateMachine.States[nameof(ClientTalkState)]);
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