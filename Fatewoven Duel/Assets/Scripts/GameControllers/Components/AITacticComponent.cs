using System;
using UnityEngine.Serialization;

namespace GameControllers.Components
{
    [Serializable]
    public struct AITacticComponent
    {
        public const int AdditionalDelayAttack = 1;
        public float CurrentDelayAttack;
        public float CurrentDelayJump;
    }
}

