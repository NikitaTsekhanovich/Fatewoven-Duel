using System.Collections;
using GameControllers.Components;
using GameControllers.Components.Requests;
using GameControllers.Ecs;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace GameControllers.MonobehControllers
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        [SerializeField] private EntityReference _entityReference;
        private const float delayDeathAnimation = 0.7f;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<EntityReference>(out var otherEntityReference))
            {
                if (!otherEntityReference.Entity.IsAlive())
                    StartCoroutine(WaitInitEntity(otherEntityReference));
                else 
                    TriggerHandler(otherEntityReference);
            }
        }

        private void TriggerHandler(EntityReference otherEntityReference)
        {
            otherEntityReference.Entity.Get<DestroyRequest>().GameEntityType = otherEntityReference.GameEntityType;

            _entityReference.Entity.Del<MovableComponent>();
            _entityReference.Entity.Del<JumpComponent>();
            _entityReference.Entity.Del<AttackComponent>();
            _entityReference.Animator.SetBool("IsDeath", true);
            WorldHandler.GetWorld().NewEntity().Get<IncreaseScoreRequest>().TypeDeadPlayer = _entityReference.GameEntityType;
            StartCoroutine(WaitDeathDelay());
        }

        private IEnumerator WaitDeathDelay()
        {
            yield return new WaitForSeconds(delayDeathAnimation);
            _entityReference.Entity.Get<DestroyRequest>().GameEntityType = _entityReference.GameEntityType;
        }

        private IEnumerator WaitInitEntity(EntityReference otherEntityReference)
        {
            while(!otherEntityReference.Entity.IsAlive())
                yield return null;

            TriggerHandler(otherEntityReference);
        }
    }
}

