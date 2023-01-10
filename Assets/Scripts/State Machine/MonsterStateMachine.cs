using System;
using DefaultNamespace;
using MonsterStates;
using UnityEngine;

namespace State_Machine
{
    public sealed class MonsterStateMachine 
        : StateMachine
    { 
        
        public MonsterStateMachine(StateObjectBehavior stateObjectBehavior)
            : base(stateObjectBehavior)
        {
            States = new()
            {
                {
                    nameof(EatingState), new EatingState(stateObjectBehavior)
                },
                {
                    nameof(RunningState), new RunningState(stateObjectBehavior)
                },
                {
                    nameof(SleepState), new SleepState(stateObjectBehavior)
                },
                {
                    nameof(SearchPlayerState), new SearchPlayerState(stateObjectBehavior)
                },
                {
                    nameof(DeathState), new DeathState(stateObjectBehavior)
                },
                {
                    nameof(FightingState), new FightingState(stateObjectBehavior)
                },
            };
        }


        /// <summary>
        /// Здесь описывается логика переходов автомата
        /// </summary>
        public override void CheckAndChangeState()
        {
            var player = SceneData.Instance.player;
            var monster = SceneData.Instance.monster;
            
            switch (State)
            {    
                case EatingState eatingState:
                    EatingStateTransforms(monster, eatingState);
                    break;
                case RunningState runningState:
                    RunningStateTransforms(monster, player, runningState);
                    break;
                case SleepState:
                    SleepStateTransforms(monster, player);
                    break;
                case SearchPlayerState searchPlayerState:
                    SearchPlayerStateTransforms(monster, player, searchPlayerState);
                    break;
                case DeathState:
                    break;
                case FightingState:
                    FightingStateTransforms(player, monster);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SearchPlayerStateTransforms(StateObjectBehavior monster, Player player, SearchPlayerState searchPlayerState)
        {
            if (Vector3.Distance(monster.transform.position, player.transform.position) < 5 &&
                player.lvl > monster.lvl)
            {
                Initialize(States[nameof(RunningState)]);
                return;
            }

            if (searchPlayerState.timeSpandInState > 5)
            {
                Initialize(States[nameof(SleepState)]);
                return;
            }

            if (Vector3.Distance(monster.transform.position, player.transform.position) < 3)
            {
                Initialize(States[nameof(FightingState)]);
                return;
            }
            
            if (Vector3.Distance(monster.transform.position, SceneData.Instance.food.transform.position) < 1)
            {
                Initialize(States[nameof(EatingState)]);
                return;
            }
        }

        private void SleepStateTransforms(StateObjectBehavior monster, Player player)
        {
            if (Vector3.Distance(monster.transform.position, player.transform.position) < 3)
            {
                Initialize(States[nameof(FightingState)]);
                return;
            }
        }

        private void EatingStateTransforms(StateObjectBehavior monster, EatingState eatingState)
        {
            if (eatingState.timeSpandInState > 5)
            {
                Initialize(States[nameof(SleepState)]);
                return;
            }
        }

        private void RunningStateTransforms(StateObjectBehavior monster, Player player, RunningState runningState)
        {
            if (runningState.timeSpandInState > 5)
            {
                Initialize(States[nameof(SleepState)]);
                return;
            }
            
            if (Vector3.Distance(monster.transform.position, player.transform.position) < 3)
            {
                Initialize(States[nameof(FightingState)]);
                return;
            }
        }

        private void FightingStateTransforms(Player player, StateObjectBehavior monster)
        {
            if (player.hp <= 0)
            {
                Initialize(States[nameof(EatingState)]);
                return;
            }
            
            if (monster.hp <= 0)
            {
                Initialize(States[nameof(DeathState)]);
                return;
            }
        }
    }
}