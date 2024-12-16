using UnityEngine;
using System;

namespace GameControllers.Components
{
    [Serializable]
    public struct GroundCheckComponent
    {
        public LayerMask GroundMask;
        public Transform TransformCircle;
        public float RadiusCircle;
        [HideInInspector] public bool IsGrounded;
        [HideInInspector] public bool IsCanSecondJump;
    }
}

