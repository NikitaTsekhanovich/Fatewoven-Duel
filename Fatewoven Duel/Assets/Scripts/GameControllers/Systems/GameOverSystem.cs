using GameControllers.Components.Requests;
using GameControllers.Data;
using GameControllers.MonobehControllers;
using GameControllers.MonobehControllers.UIControllers;
using Leopotam.Ecs;
using LevelsControllers;
using MainMenuControllers.Store;
using PlayerData;
using SceneControllers.Properties;
using UnityEngine;

namespace GameControllers.Systems
{
    public class GameOverSystem : IEcsRunSystem
    {
        private SoundsContainer _soundsContainer;
        private readonly RuntimeData _runtimeData;
        private readonly UIContainer _uiContainer;
        private readonly EcsFilter<GameOverRequest> _gameOverFilter = null;

        public void Run()
        {
            foreach (var i in _gameOverFilter)
            {
                ref var entity = ref _gameOverFilter.GetEntity(i);
                ref var gameOverRequest = ref _gameOverFilter.Get1(i);
                
                _uiContainer.GameOverScreen.Open(
                    true, 
                    _runtimeData.ModeGame,
                    gameOverRequest.NumberWinFirstPlayer,
                    gameOverRequest.NumberWinSecondPlayer);

                if (_runtimeData.ModeGame == ModeGame.SinglePlayer)
                {
                    if ((gameOverRequest.NumberWinFirstPlayer > gameOverRequest.NumberWinSecondPlayer && 
                        _runtimeData.PlayerType == PlayerType.Boy) || 
                        (gameOverRequest.NumberWinFirstPlayer < gameOverRequest.NumberWinSecondPlayer && 
                         _runtimeData.PlayerType == PlayerType.Girl))
                    {
                        PlayerPrefs.SetInt($"{PlayerDataKeys.LevelOpenKey}{_runtimeData.IndexLevel + 1}", (int)ModeLevel.Unlock);
                        
                        if (_runtimeData.PlayerType == PlayerType.Boy)
                            PlayerPrefs.SetInt($"{StateStoreItemDataKeys.StateSkinBoyKey}{_runtimeData.IndexLevel}",
                                (int)TypeStateStoreItem.Bought);
                        else if (_runtimeData.PlayerType == PlayerType.Girl)
                            PlayerPrefs.SetInt($"{StateStoreItemDataKeys.StateSkinGirlKey}{_runtimeData.IndexLevel - 6}",
                                (int)TypeStateStoreItem.Bought);
                    }
                }
                
                _soundsContainer.GameOverSound.Play();

                entity.Del<GameOverRequest>();
            }
        }
    }
}

