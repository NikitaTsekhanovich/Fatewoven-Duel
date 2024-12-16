using UnityEngine;
using System;

namespace GameControllers.Components
{
    [Serializable]
    public struct AttackComponent
    {
        public Transform ThrowPoint;
        public GameObject BallPrefab;
        public const float DelayAttack = 1f;
        public const float TimeAttackAnimation = 0.5f;
        public float CurrentDelay;
        public AudioSource AttackSound;
    }
}

