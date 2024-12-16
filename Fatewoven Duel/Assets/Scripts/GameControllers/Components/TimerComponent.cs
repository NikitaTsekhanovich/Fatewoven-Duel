using UnityEngine;

namespace GameControllers.Components
{
    public struct TimerComponent
    {
        [HideInInspector] public int StartTime;
        [HideInInspector] public float CurrentTime;
        [HideInInspector] public bool IsStopTime;
    }
}

