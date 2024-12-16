using LevelsControllers;
using SceneControllers.Properties;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenuControllers
{
    public class MatchSettings : MonoBehaviour
    {
        [SerializeField] private BlockSwitcher _blockSwitcher;
        [SerializeField] private TMP_Text _currentTimeText;
        [SerializeField] private TMP_Text _currentRoundText;
        [SerializeField] private Button _increaseTimeButton;
        [SerializeField] private Button _decreaseTimeButton;
        [SerializeField] private Button _increaseRoundButton;
        [SerializeField] private Button _decreaseRoundButton;
        private const int minNumberTime = 20;
        private const int maxNumberTime = 90;
        private const int minNumberRounds = 2;
        private const int maxNumberRounds = 6;
        private int _currentTime = 40;
        private int _currentRound = 4;
        private bool _isSinglePlayer;

        private void Awake()
        {
            UpdateTimeText();
            UpdateRoundText();
        }

        public void ClickPlayMatch()
        {
            _blockSwitcher.StartMatch(
                -1,
                ModeGame.Multiplayer, 
                _currentTime, 
                _currentRound,
                PlayerType.Boy,
                null,
                null,
                -1,
                -1,
                null,
                null);
        }

        public void ClickIncreaseTime()
        {
            IncreaseValue(ref _currentTime, maxNumberTime, _increaseTimeButton, _decreaseTimeButton, 1);
            UpdateTimeText();
        }
        public void ClickDecreaseTime()
        {
            DecreaseValue(ref _currentTime, minNumberTime, _increaseTimeButton, _decreaseTimeButton, 1);
            UpdateTimeText();
        }

        public void ClickIncreaseRound()
        {
            IncreaseValue(ref _currentRound, maxNumberRounds, _increaseRoundButton, _decreaseRoundButton, 2);
            UpdateRoundText();
        }

        public void ClickDecreaseRound()
        {
            DecreaseValue(ref _currentRound, minNumberRounds, _increaseRoundButton, _decreaseRoundButton, 2);
            UpdateRoundText();
        }

        private void UpdateTimeText()
        {
            var minutes = _currentTime / 60;
            var seconds = _currentTime % 60;

            if (seconds < 10)
                _currentTimeText.text = $"0{minutes}:0{seconds}";
            else 
                _currentTimeText.text = $"0{minutes}:{seconds}";
        }

        private void UpdateRoundText()
        {
            _currentRoundText.text = $"{_currentRound}";
        }

        private void IncreaseValue(
            ref int currentValue, 
            int maxValue, 
            Button increaseButton,
            Button decreaseButton,
            int increaseValue)
        {
            if (currentValue < maxValue)
            {
                currentValue += increaseValue;
                decreaseButton.interactable = true;

                if (currentValue >= maxValue)
                {
                    increaseButton.interactable = false;
                }
            }
        }

        private void DecreaseValue(
            ref int currentValue, 
            int minValue, 
            Button increaseButton,
            Button decreaseButton,
            int decreaseValue)
        {
            if (currentValue > minValue)
            {
                currentValue -= decreaseValue;
                increaseButton.interactable = true;

                if (currentValue <= minValue)
                {
                    decreaseButton.interactable = false;
                }
            }
        }
    }
}

