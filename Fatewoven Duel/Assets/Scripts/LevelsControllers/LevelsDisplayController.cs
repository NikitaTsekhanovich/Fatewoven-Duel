using MainMenuControllers;
using SceneControllers;
using SceneControllers.Properties;
using TMPro;
using UnityEngine;

namespace LevelsControllers
{
    public class LevelsDisplayController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lockText;
        [SerializeField] private LevelItem[] _levelsItems;
        [SerializeField] private BlockSwitcher _blockSwitcher;

        private void Start()
        {
            if (LevelDataContainer.LevelData[6].ModeLevel == ModeLevel.Lock)
                _lockText.enabled = true;
            else
                _lockText.enabled = false;
            
            InitLevelsItems();
        }

        private void InitLevelsItems()
        {
            for (var i = 0; i < _levelsItems.Length; i++)
            {
                _levelsItems[i].InitItem(LevelDataContainer.LevelData[i].ModeLevel, i, ChooseLevel);
            }
        }

        private void ChooseLevel(int index)
        {
            var levelData = LevelDataContainer.LevelData[index];

            SkinCharacter skinBoy = null;
            SkinCharacter skinGirl = null;
            
            if (levelData.PlayerType == PlayerType.Boy)
                skinGirl = levelData.SkinCharacter;
            else if (levelData.PlayerType == PlayerType.Girl)
                skinBoy = levelData.SkinCharacter;
            
            _blockSwitcher.StartMatch(
                levelData.Index,
                ModeGame.SinglePlayer, 
                levelData.TimeRound, 
                levelData.AmountRounds,
                levelData.PlayerType,
                skinBoy,
                skinGirl,
                levelData.DelayAttackAI,
                levelData.DelayJumpAI,
                levelData.PlayerDialogue,
                levelData.EnemyDialogue);
        }
    }
}
