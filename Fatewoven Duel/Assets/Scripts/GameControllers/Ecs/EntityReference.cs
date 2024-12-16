using GameControllers.EntitesTypes;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Ecs
{
    public class EntityReference : MonoBehaviour
    {
        public EcsEntity Entity;
        public GameEntityType GameEntityType;
        public Animator Animator;
    }
}

