using System;
using Hercules_States;
using UnityEngine;
using Random = UnityEngine.Random;

namespace State_Machine
{
    public sealed class HerculesStateMachine 
        : StateMachine
    {
        public HerculesStateMachine(StateObjectBehavior stateObjectBehavior)
            : base(stateObjectBehavior)
        {
            States = new()
            {
                {
                    "Homecomming", new HomeCommingState(stateObjectBehavior)
                },
                {
                    "Rolling", new RollingBallState(stateObjectBehavior)
                },
                {
                    "Sleep", new SleepState(stateObjectBehavior)
                },
                {
                    "Search Ball", new SearchBallState(stateObjectBehavior)
                },
                {
                    "Sitting", new SittingState(stateObjectBehavior)
                },
            };
        }


        /// <summary>
        /// Здесь описывается логика переходов автомата
        /// </summary>
        public override void CheckAndChangeState()
        {
            var hercules = SceneData.Instance.Hercules;
            var home = SceneData.Instance.Home;
            var ball = SceneData.Instance.CurrentBall;
            switch (State)
            {    
                case RollingBallState rollingBallState:
                    if (rollingBallState.timeSpandInState > 5f)
                        Initialize(States["Sitting"]);
                    break;
                case HomeCommingState runningState:
                    if (Vector3.Distance(hercules.transform.position, home.position) < 2f)
                        Initialize(States["Sleep"]);
                    break;
                case SleepState sleepState:
                    if (sleepState.timeSpandInState > 5f)
                        Initialize(States["Search Ball"]);
                    break;
                case SearchBallState searchBallState:
                    if (Vector3.Distance(ball.transform.position, hercules.transform.position) >= 3f)
                        return;
                    if (ball.RollingScale > 5 && Random.Range(0, 1) == 1)
                        Initialize(States["Sitting"]);
                    else 
                        Initialize(States["Rolling"]);
                    break;
                case SittingState sittingState:
                    if (sittingState.timeSpandInState > 5f)
                        Initialize(States["Homecomming"]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}