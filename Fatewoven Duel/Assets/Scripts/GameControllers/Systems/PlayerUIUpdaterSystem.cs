using GameControllers.Components;
using GameControllers.Components.Events;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.Systems
{
    public class PlayerUIUpdaterSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerUIUpdaterComponent, PlayerUIUpdateRequest> _playerUIFilter = null;

        public void Run()
        {
            foreach (var i in _playerUIFilter)
            {
                ref var entity = ref _playerUIFilter.GetEntity(i);
                ref var playerUIUpdaterComponent = ref _playerUIFilter.Get1(i);
                ref var playerUIUpdateRequest = ref _playerUIFilter.Get2(i);

                ChangeJumpButtonImage(
                    playerUIUpdateRequest.IsFirstJump,
                    playerUIUpdaterComponent.JumpButtonImage,
                    playerUIUpdaterComponent.FirstJumpSprite,
                    playerUIUpdaterComponent.SecondJumpSprite);

                entity.Del<PlayerUIUpdateRequest>();
            }
        }

        private void ChangeJumpButtonImage(
            bool isFirstJump,
            Image jumpButtonImage,
            Sprite firstJumpSprite,
            Sprite secondJumpSprite)
        {
            jumpButtonImage.sprite = isFirstJump ? firstJumpSprite : secondJumpSprite;
        }
    }
}

