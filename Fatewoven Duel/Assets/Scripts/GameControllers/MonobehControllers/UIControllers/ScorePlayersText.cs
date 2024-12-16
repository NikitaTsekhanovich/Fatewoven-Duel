using DG.Tweening;
using TMPro;
using UnityEngine;

namespace GameControllers.MonobehControllers.UIControllers
{
    public class ScorePlayersText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scorePlayer1;
        [SerializeField] private TMP_Text _scorePlayer2;
        private const float animationTime = 0.5f;
        private Color _customPurpleColor = new Color(0.2941177f, 0.1411765f, 0.345098f);

        public void UpdateScorePlayer1(int score)
        {
            IncreaseScoreAnimation(_scorePlayer1);
            _scorePlayer1.text = $"{score}";
        }

        public void UpdateScorePlayer2(int score)
        {
            IncreaseScoreAnimation(_scorePlayer2);
            _scorePlayer2.text = $"{score}";
        }

        private void IncreaseScoreAnimation(TMP_Text scoreText)
        {
            DOTween.Sequence()
                .Append(scoreText.DOColor(Color.green, animationTime))
                .Append(scoreText.DOColor(_customPurpleColor, animationTime));
        }
    }
}

