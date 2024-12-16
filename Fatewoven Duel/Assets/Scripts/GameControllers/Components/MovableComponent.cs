using UnityEngine;
using System;

namespace GameControllers.Components
{
    [Serializable]
    public struct MovableComponent
    {
        public Vector3 Direction;
        public float Speed;
    }
}

