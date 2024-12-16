using Leopotam.Ecs;
using LevelsControllers;
using MainMenuControllers.Store;
using SceneControllers;
using SceneControllers.Properties;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameControllers.Data
{
    public class RuntimeData : MonoBehaviour
    {
        public EcsEntity SingleScorePlayerEntity;
        public EcsEntity RoundsEntity;
        public EcsEntity TimerEntity;
        public ModeGame ModeGame;
        [FormerlySerializedAs("IsChosenBoy")] public PlayerType PlayerType;
        public int ScorePlayer1;
        public int ScorePlayer2;
        public SkinCharacter SkinBoyData;
        public SkinCharacter SkinGirlData;
        public int TimeRound;
        public int NumberRounds;
        public bool IsStopGame;
        public int IndexLevel;
        public float DelayAttackAI;
        public float DelayJumpAI;
    }
}

