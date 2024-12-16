using System;
using UnityEngine;

namespace GameControllers.Components
{
    [Serializable]
    public struct JumpComponent
    {
        public float Force;
        public AudioSource JumpSound;
    }
}

