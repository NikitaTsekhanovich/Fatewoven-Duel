using DG.Tweening;
using GameControllers.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class BallAnimationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BallAnimatorComponent, TransformComponent> _ballAnimatorFilter = null;

        public void Run()
        {
            foreach (var i in _ballAnimatorFilter)
            {
                ref var entity = ref _ballAnimatorFilter.GetEntity(i);
                ref var transformComponent = ref _ballAnimatorFilter.Get2(i); 
                ref var transform = ref transformComponent.Transform;

                transform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Incremental);

                entity.Del<BallAnimatorComponent>();
            }
        }
    }
}

