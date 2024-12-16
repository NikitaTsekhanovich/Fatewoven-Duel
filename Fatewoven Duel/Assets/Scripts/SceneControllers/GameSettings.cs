using System;
using LevelsControllers;
using MainMenuControllers.Store;
using SceneControllers.Properties;

namespace SceneControllers
{
    [Serializable]
    public class GameSettings
    {
        public int IndexLevel;
        public ModeGame ModeGame;
        public int TimeRound;
        public int NumberRounds;
        public PlayerType PlayerType;
        public SkinCharacter SkinBoyData;
        public SkinCharacter SkinGirlData;
        public float DelayAttackAI;
        public float DelayJumpAI;
        public string PlayerDialogue;
        public string EnemyDialogue;

        public GameSettings(
            int indexLevel,
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
            IndexLevel = indexLevel;
            ModeGame = modeGame;
            TimeRound = timeRound;
            NumberRounds = numberRounds;
            PlayerType = playerType;
            SkinBoyData = skinBoyData;
            SkinGirlData = skinGirlData;
            DelayAttackAI = delayAttackAI;
            DelayJumpAI = delayJumpAI;
            PlayerDialogue = playerDialogue;
            EnemyDialogue = enemyDialogue;
        }
    }
}
