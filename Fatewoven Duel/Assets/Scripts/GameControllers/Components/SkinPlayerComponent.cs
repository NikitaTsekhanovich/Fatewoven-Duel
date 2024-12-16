using UnityEngine;
using System;
using GameControllers.Ecs;

namespace GameControllers.Components
{
    [Serializable]
    public struct SkinPlayerComponent
    {
        public SpriteRenderer Head;
        public SpriteRenderer Body;
        public SpriteRenderer Hand;
        public EntityReference EntityReference;
    }
}

