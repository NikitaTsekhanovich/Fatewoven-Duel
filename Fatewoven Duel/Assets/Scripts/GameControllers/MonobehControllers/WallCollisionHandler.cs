using GameControllers.Components.Requests;
using GameControllers.Ecs;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.MonobehControllers
{
    public class WallCollisionHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<EntityReference>(out var entityReference))
                entityReference.Entity.Get<DestroyRequest>().GameEntityType = EntitesTypes.GameEntityType.Ball;
        }
    }
}
