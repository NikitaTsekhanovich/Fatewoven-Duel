using PlayerData;
using SceneControllers;
using SceneControllers.Properties;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voody.UniLeo;

namespace GameControllers.MonobehControllers.UIControllers
{
    public class GameOverScreen : Screen
    {
        [SerializeField] private GameObject _infoSingleBlock;
        [SerializeField] private GameObject _infoMultiplayerBlock;
        [SerializeField] private Image _boyIcon;
        [SerializeField] private Image _girlIcon;
        [SerializeField] private Sprite _boyWinIcon;
        [SerializeField] private Sprite _girlWinIcon;
        [SerializeField] private TMP_Text _scoreBoy;
        [SerializeField] private TMP_Text _scoreGirl;
        [SerializeField] private TMP_Text _bestSingleScore;
        [SerializeField] private GameObject _winFramePlayer1;
        [SerializeField] private GameObject _winFramePlayer2;
        [SerializeField] private GameObject _drawFrame;

        public void Open(bool isActive, ModeGame modeGame, int scoreFirstPlayer, int scoreSecondPlayer)
        {
            Time.timeScale = 0;

            UpdateInfo(modeGame, scoreFirstPlayer, scoreSecondPlayer);
            ChangeStateScreen(isActive);
        }

        private void UpdateInfo(ModeGame modeGame, int scoreFirstPlayer, int scoreSecondPlayer)
        {
            _bestSingleScore.text = $"{PlayerPrefs.GetInt(PlayerDataKeys.BestScoreKey)}";
            _scoreBoy.text = $"{scoreFirstPlayer}";
            _scoreGirl.text = $"{scoreSecondPlayer}";

            if (modeGame == ModeGame.Multiplayer)
            {
                _infoMultiplayerBlock.SetActive(true);
            }

            if (modeGame == ModeGame.SinglePlayer)
            {
                _infoSingleBlock.SetActive(true);
            }

            if (scoreFirstPlayer > scoreSecondPlayer)
            {
                _boyIcon.sprite = _boyWinIcon;
                _winFramePlayer1.SetActive(true);
            }
            else if (scoreFirstPlayer < scoreSecondPlayer)
            {
                _girlIcon.sprite = _girlWinIcon;
                _winFramePlayer2.SetActive(true);
            }
            else
            {
                _boyIcon.sprite = _boyWinIcon;
                _girlIcon.sprite = _girlWinIcon;
                _drawFrame.SetActive(true);
            }
        }

        public void ClickPause()
        {
            Time.timeScale = 0f;
        }

        public void ClickResume()
        {
            Time.timeScale = 1f;
        }
        
        public void ClickRestartGame()
        {
            ClearEcsWorld();
            Time.timeScale = 1f;
            LoadingScreenController.Instance.ChangeScene("Game");
        }

        public void ClickBackToMenu()
        {
            ClearEcsWorld();
            Time.timeScale = 1f;
            LoadingScreenController.Instance.ChangeScene("MainMenu");
        }

        private void ClearEcsWorld()
        {
            WorldHandler.GetWorld().Destroy();
        }
    }
}

