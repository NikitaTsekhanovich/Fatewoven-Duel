using GameControllers.Components;
using GameControllers.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly RuntimeData _runtimeData;
        private readonly EcsFilter<MovableComponent, TransformComponent> _movementFilter = null;

        public void Run()
        {
            foreach (var i in _movementFilter)
            {
                if (_runtimeData.IsStopGame) return;

                ref var movableComponent = ref _movementFilter.Get1(i);
                ref var transformComponent = ref _movementFilter.Get2(i);

                transformComponent.Transform.position += movableComponent.Direction * movableComponent.Speed * Time.deltaTime;
            }
        }
    }
}

