using System;
using Rat_States;
using UnityEngine;

namespace State_Machine
{
    public sealed class RatStateMachine 
        : StateMachine
    {
        public RatStateMachine(StateObjectBehavior stateObjectBehavior)
            : base(stateObjectBehavior)
        {
            States = new()
            {
                {
                    "Eat", new EatingState(stateObjectBehavior)
                },
                {
                    "Run", new RunningState(stateObjectBehavior)
                },
                {
                    "Sleep", new SleepState(stateObjectBehavior)
                },
                {
                    "Search Cheese", new SearchCheeseState(stateObjectBehavior)
                },
                {
                    "Death", new DeathState(stateObjectBehavior)
                },
            };
        }

        public void TakeDamage()
        {
            Initialize(States["Death"]);
        }


        /// <summary>
        /// Здесь описывается логика переходов автомата
        /// </summary>
        public override void CheckAndChangeState()
        {
            var cat = SceneData.Instance.Cat;
            var rat = SceneData.Instance.Rat;
            
            switch (State)
            {    
                case EatingState eatingState:
                    EatingStateTransforms(cat, rat, eatingState);
                    break;
                case RunningState runningState:
                    RunningStateTransforms(cat, rat, runningState);
                    break;
                case SleepState sleepState:
                    SleepStateTransforms(cat, rat, sleepState);
                    break;
                case SearchCheeseState searchCheeseState:
                    SearchCheeseStateTransforms(cat, rat, searchCheeseState);
                    break;
                case DeathState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RunningStateTransforms(StateObjectBehavior cat, StateObjectBehavior rat, RunningState runningState)
        {
        }
        
        private void SleepStateTransforms(StateObjectBehavior cat, StateObjectBehavior rat, SleepState sleepState)
        {
            if (sleepState.timeSpandInState > 3f)
                Initialize(States["Search Cheese"]);
            
            if (Vector3.Distance(cat.transform.position, rat.transform.position) < 5f)
            {
                Initialize(States["Run"]);
                return;
            }
        }
        
        private void SearchCheeseStateTransforms(StateObjectBehavior cat, StateObjectBehavior rat, SearchCheeseState runningState)
        {
            var cheese = SceneData.Instance.cheese.position;
            if (Vector3.Distance(cheese, rat.transform.position) < 1.0f)
                Initialize(States["Eat"]);
            
            if (Vector3.Distance(cat.transform.position, rat.transform.position) < 5f)
            {
                Initialize(States["Run"]);
                return;
            }
        }

        private void EatingStateTransforms(StateObjectBehavior cat, StateObjectBehavior rat, EatingState eatingState)
        {
            if (Vector3.Distance(cat.transform.position, rat.transform.position) < 5f)
            {
                Initialize(States["Run"]);
                return;
            }

            if (eatingState.timeSpandInState > 5f)
            {
                Initialize(States["Sleep"]);
                return;
            }
        }
    }
}