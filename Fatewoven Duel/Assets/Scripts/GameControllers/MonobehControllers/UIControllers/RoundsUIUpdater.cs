using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllers.MonobehControllers.UIControllers
{
    public class RoundsUIUpdater : MonoBehaviour
    {
        [SerializeField] private Transform _parentRounds;
        [SerializeField] private GameObject _firstPlayerRoundImage;
        [SerializeField] private GameObject _secondPlayerRoundImage;
        [SerializeField] private Sprite _firstPlayerWinSprite;
        [SerializeField] private Sprite _secondPlayerWinSprite;
        private List<Image> _roundsFirstPlayerImages = new(); 
        private List<Image> _roundsSecondPlayerImages = new(); 
        private int _currentWinsFirstPlayer;
        private int _currentWinsSecondPlayer;

        public void Init(int nubmerRounds)
        {
            SpawnRoundsImage(nubmerRounds / 2, _roundsFirstPlayerImages, _firstPlayerRoundImage);
            SpawnRoundsImage(nubmerRounds / 2, _roundsSecondPlayerImages, _secondPlayerRoundImage);
            _roundsSecondPlayerImages.Reverse();
        }

        public void UpdateRounds(TypeEndRound typeEndRound)
        {
            if (typeEndRound == TypeEndRound.FirstPlayerWin)
            {
                _roundsFirstPlayerImages[_currentWinsFirstPlayer].sprite = _firstPlayerWinSprite;
                _currentWinsFirstPlayer++;
            }
            else if (typeEndRound == TypeEndRound.SecondPlayerWin)
            {
                _roundsSecondPlayerImages[_currentWinsSecondPlayer].sprite = _secondPlayerWinSprite;
                _currentWinsSecondPlayer++;
            }
            else if (typeEndRound == TypeEndRound.Draw)
            {
                _roundsFirstPlayerImages[_currentWinsFirstPlayer].sprite = _firstPlayerWinSprite;
                _roundsSecondPlayerImages[_currentWinsSecondPlayer].sprite = _secondPlayerWinSprite;
                _currentWinsFirstPlayer++;
                _currentWinsSecondPlayer++;
            }
        }

        private void SpawnRoundsImage(int nubmerRoundsPlayer, List<Image> roundsPlayerImages, GameObject playerRoundImage)
        {
            for (var i = 0; i < nubmerRoundsPlayer; i++)
            {
                var roundImage = Instantiate(playerRoundImage, _parentRounds).GetComponent<Image>();
                roundsPlayerImages.Add(roundImage);
            }
        }
    }
}

