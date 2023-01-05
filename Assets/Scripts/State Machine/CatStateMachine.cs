using System;
using Cat_States;
using UnityEngine;

namespace State_Machine
{
    public sealed partial class CatStateMachine 
        : StateMachine
    {
        private readonly LayerMask _ratLayerMask;
        
        public CatStateMachine(LayerMask ratLayerMask, StateObjectBehavior stateObjectBehavior)
            :base(stateObjectBehavior)
        {
            States = new()
            {
                {"Eat", new EatingState(stateObjectBehavior)},
                {"Hunt", new HuntingState(stateObjectBehavior)},
                {"Patrol", new PatrolState(stateObjectBehavior, SceneData.Instance.patrolPoints)},
                {"Sleep", new SleepState(stateObjectBehavior)},
            };
            _ratLayerMask = ratLayerMask;
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
                case HuntingState huntingState:
                    HuntingStateTransforms(cat, rat, huntingState);
                    break;
                case SleepState sleepState:
                    SleepStateTransforms(cat, rat, sleepState);
                    break;
                case PatrolState patrol:
                    PatrolStateTransforms(cat, rat, patrol);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}