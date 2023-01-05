using Cat_States;
using UnityEngine;

namespace State_Machine
{
    public sealed partial class CatStateMachine
    {
        private void HuntingStateTransforms(StateObjectBehavior cat, StateObjectBehavior rat, HuntingState huntingState)
        {
            if (Vector3.Distance(cat.transform.position, rat.transform.position) < 1.0f)
            {
                Initialize(States["Eat"]);
                return;
            }

            if (Vector3.Distance(cat.transform.position, rat.transform.position) > 1.0f)
            {
                if (huntingState.timeSpandInState > 5f)
                {
                    Initialize(States["Patrol"]);
                    return;
                }
            }
        }

        private void SleepStateTransforms(StateObjectBehavior cat, StateObjectBehavior rat, SleepState runningState)
        {
            if (runningState.timeSpandInState > 5f)
                Initialize(States["Patrol"]);
        }

        private void PatrolStateTransforms(StateObjectBehavior cat, StateObjectBehavior rat, PatrolState patrol)
        {
            if (Vector3.Distance(cat.transform.position, rat.transform.position) < 3.5f)
                Initialize(States["Hunt"]);
        }

        private void EatingStateTransforms(StateObjectBehavior cat, StateObjectBehavior rat, EatingState eatingState)
        {
            if (eatingState.timeSpandInState > 5f)
            {
                Initialize(States["Sleep"]);
                return;
            }
        }
    }
}