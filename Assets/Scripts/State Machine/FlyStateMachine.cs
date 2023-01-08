using System;
using Fly_States;
using UnityEngine;
using Random = UnityEngine.Random;

namespace State_Machine
{
    public sealed class FlyStateMachine 
        : StateMachine
    {
        public FlyStateMachine(StateObjectBehavior stateObjectBehavior)
            : base(stateObjectBehavior)
        {
            States = new()
            {
                {
                    "Patrol", new PatrolState(stateObjectBehavior)
                },
                {
                    "Run", new RunningState(stateObjectBehavior)
                },
                {
                    "Hunt", new HuntingState(stateObjectBehavior)
                },
                {
                    "Eat", new EatingState(stateObjectBehavior)
                },
                {
                    "RoundingMove", new RoundingMoveState(stateObjectBehavior)
                },
            };

            Initialize(States["Patrol"]);
        }


        /// <summary>
        /// Здесь описывается логика переходов автомата
        /// </summary>
        public override void CheckAndChangeState()
        {
            var fly = SceneData.Instance.Fly;
            var player = SceneData.Instance.Player;

            var distance = Vector3.Distance(player.transform.position, fly.transform.position);
            
            switch (State)
            {    
                case PatrolState patrolState:
                        PatrolStateTransform(fly, player, distance, patrolState.timeSpandInState);
                    break;
                case RoundingMoveState randomMoveState:
                    if (randomMoveState.timeSpandInState > 5f)
                        Initialize(States["Run"]);
                    break;
                case RunningState runningState:
                        RunningStateTransform(fly, player, distance, runningState.timeSpandInState);
                    break;
                case HuntingState huntingState:
                        HuntingStateTransform(fly, player, distance);
                    break;
                case EatingState eatingState:
                        if (eatingState.timeSpandInState > 5f)
                            Initialize(States["Patrol"]);
                        if (distance < 5f)
                            Initialize(States["Run"]);
                        break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void PatrolStateTransform(StateObjectBehavior fly, GameObject player, float distance, float timeSpand)
        {
            if (timeSpand > 10f)
            {
                Initialize(States["Hunt"]);
                return;
            }
            
            if (distance < 5f)
            {
                Initialize(States["Run"]);
                return;
            }
            
        }

        private void HuntingStateTransform(StateObjectBehavior fly, GameObject player, float distanceToPlayer)
        {
            var distanceToEat = Vector3.Distance(fly.transform.position, SceneData.Instance.EatPlace.position);
            if (distanceToPlayer < 5f)
            {
                Initialize(States["Run"]);
                return;
            }

            if (distanceToEat < 2f)
                Initialize(States["Eat"]);
        }
        
        private void RunningStateTransform(StateObjectBehavior fly, GameObject player, float distance, float timeSpand)
        {
            if (distance > 5f)
            {
                if (Random.Range(0,20) > 5)
                    Initialize(States["Patrol"]);
                else 
                    Initialize(States["Hunt"]);
                return;
            }

            if (timeSpand > 5f)
                Initialize(States["RoundingMove"]);
        }
    }
}