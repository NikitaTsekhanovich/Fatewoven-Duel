using System;
using LevelsControllers;
using MainMenuControllers.Store;
using SceneControllers;
using SceneControllers.Properties;
using UnityEngine;

namespace MainMenuControllers
{
    public class BlockSwitcher : MonoBehaviour
    {
        public static Action<GameSettings> OnStashMatchSettings;
        
        private void Awake()
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        public void StartMatch(
            int levelIndex,
            ModeGame modeGame, 
            int timeRound, 
            int numberRounds, 
            PlayerType playerType,
            SkinCharacter skinBoyData, 
            SkinCharacter skinGirlData,
            float delayAttackAI,
            float delayJumpAI,
            string playerDialogue,
            string enemyDialogue)
        {
            var gameSettings = new GameSettings(
                levelIndex,
                modeGame, 
                timeRound, 
                numberRounds, 
                playerType, 
                skinBoyData, 
                skinGirlData,
                delayAttackAI,
                delayJumpAI,
                playerDialogue,
                enemyDialogue);

            OnStashMatchSettings.Invoke(gameSettings);
            LoadingScreenController.Instance.ChangeScene("Game");
        }
    }
}
