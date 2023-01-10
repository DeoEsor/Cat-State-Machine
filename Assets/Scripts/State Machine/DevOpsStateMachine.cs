using System;
using System.Collections.Generic;
using Contracts;
using DevOps_States;
using UnityEngine;

namespace State_Machine
{
    public sealed class DevOpsStateMachine : StateMachine
    {

        public SceneData data = SceneData.Instance;
        
        public DevOpsStateMachine(StateObjectBehavior stateObjectBehavior)
            : base(stateObjectBehavior)
        {
            States = new Dictionary<string, IState>
            {
                {
                    nameof(WriteCodeState), new WriteCodeState(stateObjectBehavior)
                },
                {
                    nameof(WatchMonitoringState), new WatchMonitoringState(stateObjectBehavior)
                },
                {
                    nameof(SleepState), new SleepState(stateObjectBehavior)
                },
                {
                    nameof(PushCodeState), new PushCodeState(stateObjectBehavior)
                },
                {
                    nameof(ClientTalkState), new ClientTalkState(stateObjectBehavior)
                },
            };
        }

        /// <summary>
        /// Здесь описывается логика переходов автомата
        /// </summary>
        public override void CheckAndChangeState()
        {   
            
            switch (State)
            {    
                case SleepState state:
                    SleepStateTransforms(state);
                    break;
                case WriteCodeState state:
                    WriteCodeStateTransforms(state);
                    break;
                case WatchMonitoringState state:
                    WatchMonitoringStateTransforms(state);
                    break;
                case PushCodeState state:
                    PushCodeStateTransforms(state);
                    break;
                case ClientTalkState state:
                    ClientTalkStateTransforms(state);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ClientTalkStateTransforms(ClientTalkState state)
        {
            if (state.timeSpandInState < 7f)
                return;

            if (data.timeSpendWithoutMonitor > 50)
            {
                Initialize(States[nameof(WatchMonitoringState)]);
                return;
            }

            if (data.procentageOfWreckedCode > 50)
            {
                Initialize(States[nameof(WriteCodeState)]);
                return;
            }
        }

        private void PushCodeStateTransforms(PushCodeState state)
        {
            if (state.timeSpandInState < 7f)
                return;

            if (data.clientAngry > 50)
            {
                Initialize(States[nameof(ClientTalkState)]);
                return;
            }
            
            if (data.tired > 50)
            {
                Initialize(States[nameof(SleepState)]);
                return;
            }
        }

        private void WatchMonitoringStateTransforms(WatchMonitoringState state)
        {
            if (state.timeSpandInState < 7f)
                return;
            
            if (data.procentageOfWreckedCode > 50)
            {
                Initialize(States[nameof(WriteCodeState)]);
                return;
            }

            if (data.clientAngry > 50)
            {
                Initialize(States[nameof(ClientTalkState)]);
                return;
            }
            
            if (data.tired > 50)
            {
                Initialize(States[nameof(SleepState)]);
                return;
            }
        }

        private void SleepStateTransforms(SleepState state)
        {
            if (state.timeSpandInState < 7f)
                return;
            
            if (data.timeSpendWithoutMonitor > 50)
            {
                Initialize(States[nameof(WatchMonitoringState)]);
                return;
            }

            if (data.procentageOfWreckedCode > 50)
            {
                Initialize(States[nameof(WriteCodeState)]);
                return;
            }
            
            if (data.clientAngry > 50)
            {
                Initialize(States[nameof(ClientTalkState)]);
                return;
            }
        }
        
        private void WriteCodeStateTransforms(WriteCodeState state)
        {
            if (state.timeSpandInState < 7f)
                return;
            
            if (data.readyOfPatch >= 50)
            {
                Initialize(States[nameof(PushCodeState)]);
                return;
            }

            if (data.timeSpendWithoutMonitor > 50)
            {
                Initialize(States[nameof(WatchMonitoringState)]);
                return;
            }
            
            if (data.tired > 50)
            {
                Initialize(States[nameof(SleepState)]);
                return;
            }
        }
    }
}