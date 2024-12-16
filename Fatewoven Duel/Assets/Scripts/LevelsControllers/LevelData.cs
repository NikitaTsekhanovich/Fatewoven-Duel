using PlayerData;
using SceneControllers;
using UnityEngine;

namespace LevelsControllers
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Levels data/ level data")]
    public class LevelData : ScriptableObject
    {
        [Header("Level info")]
        [SerializeField] private int _index;
        [SerializeField] private PlayerType _playerType;
        
        [Header("Enemy info")]
        [SerializeField] private SkinCharacter _skinCharacter;
        [SerializeField] private float _delayAttackAI;
        [SerializeField] private float _delayJumpAI;
        
        [Header("Dialogue info")]
        [SerializeField] private string _playerDialogue;
        [SerializeField] private string _enemyDialogue;
        
        [Header("Game settings info")]
        [SerializeField] private int _amountRounds;
        [SerializeField] private int _timeRound;
        

        public int Index => _index;
        public PlayerType PlayerType => _playerType;
        public SkinCharacter SkinCharacter => _skinCharacter;
        public float DelayAttackAI => _delayAttackAI;
        public float DelayJumpAI => _delayJumpAI;
        public string PlayerDialogue => _playerDialogue;
        public string EnemyDialogue => _enemyDialogue;
        public int AmountRounds => _amountRounds;
        public int TimeRound => _timeRound;

        public ModeLevel ModeLevel
        {
            get
            {
                var currentModeGame = PlayerPrefs.GetInt($"{PlayerDataKeys.LevelOpenKey}{_index}");
                return (ModeLevel)currentModeGame;
            }
            
        }
    }
}
