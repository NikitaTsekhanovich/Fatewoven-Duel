using DG.Tweening;
using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class AttackSystem : IEcsRunSystem
    {
        private readonly RuntimeData _runtimeData;
        private readonly EcsFilter<AttackComponent, PlayerAnimatiorComponent> _attackFilter = null;
        private readonly EcsFilter<AttackEvent> _attackEventFilter = null;

        public void Run()
        {
            foreach (var i in _attackFilter)
            {
                if (_runtimeData.IsStopGame) return;

                ref var attackPlayerEntity = ref _attackFilter.GetEntity(i);
                ref var attackComponent = ref _attackFilter.Get1(i);
                ref var animatiorComponent = ref _attackFilter.Get2(i);
                ref var currentDelay = ref attackComponent.CurrentDelay;

                CalculateDelayAttack(ref currentDelay, ref animatiorComponent);

                foreach (var j in _attackEventFilter)
                {
                    ref var entity = ref _attackEventFilter.GetEntity(j);

                    if (attackPlayerEntity.GetInternalId() != entity.GetInternalId()) continue;

                    if (currentDelay >= AttackComponent.DelayAttack)
                    {
                        currentDelay = 0;
                        animatiorComponent.Animator.SetBool("IsAttack", true);
                        SpawnAttackPrefab(attackComponent);
                        attackComponent.AttackSound.Play();
                    }

                    entity.Del<AttackEvent>();
                }
            }
        }

        private void CalculateDelayAttack(ref float currentDelay, ref PlayerAnimatiorComponent animatiorComponent)
        {
            currentDelay += Time.deltaTime;

            if (currentDelay >= AttackComponent.TimeAttackAnimation)
                animatiorComponent.Animator.SetBool("IsAttack", false);
        }

        private void SpawnAttackPrefab(AttackComponent attackComponent)
        {
            DOTween.Sequence()
                .AppendInterval(AttackComponent.TimeAttackAnimation)
                .AppendCallback(() => Object.Instantiate(
                                        attackComponent.BallPrefab,
                                        attackComponent.ThrowPoint.position, 
                                        attackComponent.ThrowPoint.rotation));
        }
    }
}

