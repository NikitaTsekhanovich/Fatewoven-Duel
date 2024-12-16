using GameControllers.Components;
using GameControllers.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class SkinPlayerSystem : IEcsRunSystem
    {
        private readonly RuntimeData _runtimeData;
        private readonly EcsFilter<SkinPlayerComponent> _skinPlayerFilter = null;

        public void Run()
        {
            foreach (var i in _skinPlayerFilter)
            {
                ref var entity = ref _skinPlayerFilter.GetEntity(i);

                ref var skinPlayerComponent = ref _skinPlayerFilter.Get1(i);
                ref var body = ref skinPlayerComponent.Body;
                ref var head = ref skinPlayerComponent.Head;
                ref var hand = ref skinPlayerComponent.Hand;
                ref var entityReference = ref skinPlayerComponent.EntityReference;

                if (entityReference.GameEntityType == EntitesTypes.GameEntityType.FirstPlayer)
                {
                    body.sprite = _runtimeData.SkinBoyData.BodySprite;
                    head.sprite = _runtimeData.SkinBoyData.HeadSprite;
                    hand.sprite = _runtimeData.SkinBoyData.HandSprite;
                }
                else if (entityReference.GameEntityType == EntitesTypes.GameEntityType.SecondPlayer)
                {
                    body.sprite = _runtimeData.SkinGirlData.BodySprite;
                    head.sprite = _runtimeData.SkinGirlData.HeadSprite;
                    hand.sprite = _runtimeData.SkinGirlData.HandSprite;
                }

                entity.Del<SkinPlayerComponent>();
            }
        }
    }
}

