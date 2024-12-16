using GameControllers.Components;
using GameControllers.Components.Requests;
using GameControllers.Data;
using GameControllers.EntitesTypes;
using Leopotam.Ecs;
using LevelsControllers;
using SceneControllers.Properties;
using UnityEngine;

namespace GameControllers.Systems
{
    public class SpawnPlayerSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly RuntimeData _runtimeData;
        private readonly EcsFilter<SpawnPlayerComponent> _respawnPlayerFilter = null;
        private readonly EcsFilter<RespawnPlayerRequest> _respawnPlayerRequestFilter = null;

        public void Init()
        {
            foreach (var i in _respawnPlayerFilter)
            {
                ref var entity = ref _respawnPlayerFilter.GetEntity(i);
                ref var respawnPlayerComponent = ref _respawnPlayerFilter.Get1(i);

                ChooseTypeSpawn(respawnPlayerComponent);

                entity.Del<RespawnPlayerRequest>();
            }
        }

        public void Run()
        {
            foreach (var i in _respawnPlayerFilter)
            {
                ref var respawnPlayerComponent = ref _respawnPlayerFilter.Get1(i);

                foreach (var j in _respawnPlayerRequestFilter)
                {
                    ref var entity = ref _respawnPlayerRequestFilter.GetEntity(j);
                    ref var respawnPlayerRequest = ref _respawnPlayerRequestFilter.Get1(j);

                    if (_runtimeData.ModeGame == ModeGame.Multiplayer)
                    {
                        if (respawnPlayerRequest.PlayerType == GameEntityType.FirstPlayer)
                            SpawnPlayer(respawnPlayerComponent.Player1, respawnPlayerComponent.RespawnPointPlayer1);
                        else
                            SpawnPlayer(respawnPlayerComponent.Player2, respawnPlayerComponent.RespawnPointPlayer2);
                    }
                    else if (_runtimeData.ModeGame == ModeGame.SinglePlayer)
                    {
                        if (respawnPlayerRequest.PlayerType == GameEntityType.FirstPlayer)
                        {
                            if (_runtimeData.PlayerType == PlayerType.Boy)
                                SpawnPlayer(respawnPlayerComponent.Player1, respawnPlayerComponent.RespawnPointPlayer1);
                            else 
                                SpawnPlayer(respawnPlayerComponent.Player1AI, respawnPlayerComponent.RespawnPointPlayer1);
                        }
                        else if (respawnPlayerRequest.PlayerType == GameEntityType.SecondPlayer)
                        {
                            if (_runtimeData.PlayerType == PlayerType.Girl)
                                SpawnPlayer(respawnPlayerComponent.Player2, respawnPlayerComponent.RespawnPointPlayer2);
                            else 
                                SpawnPlayer(respawnPlayerComponent.Player2AI, respawnPlayerComponent.RespawnPointPlayer2);
                        }
                    }

                    entity.Del<RespawnPlayerRequest>();
                }
            }
        }

        private void ChooseTypeSpawn(SpawnPlayerComponent respawnPlayerComponent)
        {
            if (_runtimeData.ModeGame == ModeGame.Multiplayer)
            {
                SpawnPlayer(respawnPlayerComponent.Player1, respawnPlayerComponent.RespawnPointPlayer1);
                SpawnPlayer(respawnPlayerComponent.Player2, respawnPlayerComponent.RespawnPointPlayer2);
            }
            else if (_runtimeData.ModeGame == ModeGame.SinglePlayer)
            {
                if (_runtimeData.PlayerType == PlayerType.Boy)
                {
                    SpawnPlayer(respawnPlayerComponent.Player1, respawnPlayerComponent.RespawnPointPlayer1);
                    SpawnPlayer(respawnPlayerComponent.Player2AI, respawnPlayerComponent.RespawnPointPlayer2);
                }
                else
                {
                    SpawnPlayer(respawnPlayerComponent.Player1AI, respawnPlayerComponent.RespawnPointPlayer1);
                    SpawnPlayer(respawnPlayerComponent.Player2, respawnPlayerComponent.RespawnPointPlayer2);
                }
            }
        }

        private void SpawnPlayer(GameObject player, Transform spawnPoint)
        {
            Object.Instantiate(player, spawnPoint.position, Quaternion.identity);
        }
    }
}

