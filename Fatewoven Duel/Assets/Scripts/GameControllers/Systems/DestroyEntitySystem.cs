using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Components.Requests;
using GameControllers.Data;
using GameControllers.EntitesTypes;
using GameControllers.MonobehControllers;
using Leopotam.Ecs;
using LevelsControllers;
using SceneControllers.Properties;
using UnityEngine;

namespace GameControllers.Systems
{
    public class DestroyEntitySystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private SoundsContainer _soundsContainer;
        private readonly RuntimeData _runtimeData;
        private readonly EcsFilter<TransformComponent, DestroyRequest> _destroyFilter = null;


        public void Run()
        {
            foreach (var i in _destroyFilter)
            {
                ref var entityDestroyable = ref _destroyFilter.GetEntity(i);
                ref var transformComponent = ref _destroyFilter.Get1(i);
                ref var destroyRequest = ref _destroyFilter.Get2(i);
                
                if (destroyRequest.GameEntityType == GameEntityType.FirstPlayer || destroyRequest.GameEntityType == GameEntityType.SecondPlayer)
                {
                    _world.NewEntity().Get<RespawnPlayerRequest>().PlayerType = destroyRequest.GameEntityType;
                    _soundsContainer.RespawnCharacterSound.Play();
                }

                if (_runtimeData.ModeGame == ModeGame.SinglePlayer)
                {
                    if (destroyRequest.GameEntityType == GameEntityType.FirstPlayer && _runtimeData.PlayerType == PlayerType.Girl ||
                        destroyRequest.GameEntityType == GameEntityType.SecondPlayer && _runtimeData.PlayerType == PlayerType.Boy)
                    {
                        _runtimeData.SingleScorePlayerEntity.Get<IncreaseSinglePlayerScoreEvent>();
                    }
                }

                Object.Destroy(transformComponent.Transform.gameObject);
                entityDestroyable.Destroy();
            }
        }
    }
}
