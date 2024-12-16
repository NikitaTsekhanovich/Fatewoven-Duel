using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Components.Tags;
using GameControllers.Data;
using Leopotam.Ecs;

namespace GameControllers.Systems
{
    public class RestartPositionEntitySystem : IEcsRunSystem
    {
        private readonly PlayerSpawnData _playerSpawnData;
        private readonly EcsFilter<TransformComponent, FirstPlayerTag, RestartPositionEntityEvent> _restartPositionFirstPlayerFilter = null;
        private readonly EcsFilter<TransformComponent, SecondPlayerTag, RestartPositionEntityEvent> _restartPositionSecondPlayerFilter = null;

        public void Run()
        {
            foreach (var i in _restartPositionFirstPlayerFilter)
            {
                ref var entity = ref _restartPositionFirstPlayerFilter.GetEntity(i);
                ref var transformComponent = ref _restartPositionFirstPlayerFilter.Get1(i);

                transformComponent.Transform.position = _playerSpawnData.SpawnPlayerComponent.RespawnPointPlayer1.position;

                entity.Del<RestartPositionEntityEvent>();
            }

            foreach (var i in _restartPositionSecondPlayerFilter)
            {
                ref var entity = ref _restartPositionSecondPlayerFilter.GetEntity(i);
                ref var transformComponent = ref _restartPositionSecondPlayerFilter.Get1(i);

                transformComponent.Transform.position = _playerSpawnData.SpawnPlayerComponent.RespawnPointPlayer2.position;

                entity.Del<RestartPositionEntityEvent>();
            }
        }
    }
}

