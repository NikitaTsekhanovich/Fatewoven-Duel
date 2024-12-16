using GameControllers.Components;
using GameControllers.Data;
using Leopotam.Ecs;

namespace GameControllers.Systems.Initializers
{
    public class GameInitializeSystem : IEcsPreInitSystem
    {
        private readonly RuntimeData _runtimeData;
        private readonly PlayerSpawnData _playerSpawnData;
        private readonly EcsWorld _world;

        public void PreInit()
        {
            _runtimeData.TimerEntity = _world.NewEntity();
            _runtimeData.TimerEntity.Get<TimerComponent>().StartTime = _runtimeData.TimeRound;

            _runtimeData.RoundsEntity = _world.NewEntity();
            _runtimeData.RoundsEntity.Get<RoundsComponent>().NumberRounds = _runtimeData.NumberRounds;

            _runtimeData.SingleScorePlayerEntity = _world.NewEntity();
            _runtimeData.SingleScorePlayerEntity.Get<SinglePlayerScoreComponent>();

            var newRespawnerEntity = _world.NewEntity();
            ref var spawnPlayerComponent = ref newRespawnerEntity.Get<SpawnPlayerComponent>();
            spawnPlayerComponent.Player1 = _playerSpawnData.SpawnPlayerComponent.Player1;
            spawnPlayerComponent.Player2 = _playerSpawnData.SpawnPlayerComponent.Player2;
            spawnPlayerComponent.Player1AI = _playerSpawnData.SpawnPlayerComponent.Player1AI;
            spawnPlayerComponent.Player2AI = _playerSpawnData.SpawnPlayerComponent.Player2AI;
            spawnPlayerComponent.RespawnPointPlayer1 = _playerSpawnData.SpawnPlayerComponent.RespawnPointPlayer1;
            spawnPlayerComponent.RespawnPointPlayer2 = _playerSpawnData.SpawnPlayerComponent.RespawnPointPlayer2;
        }
    }
}

