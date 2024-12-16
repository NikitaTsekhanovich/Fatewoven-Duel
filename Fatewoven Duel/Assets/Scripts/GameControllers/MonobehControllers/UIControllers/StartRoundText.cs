using DG.Tweening;
using TMPro;
using UnityEngine;

namespace GameControllers.MonobehControllers.UIControllers
{
    public class StartRoundText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _startRoundText;

        public void StartAnimationText()
        {
            _startRoundText.text = "3";

            DOTween.Sequence()
                .Append(_startRoundText.transform.DOScale(Vector3.one, 0.5f))
                .Append(_startRoundText.transform.DOScale(Vector3.zero, 0.5f))
                .AppendCallback(() => _startRoundText.text = "2")
                .Append(_startRoundText.transform.DOScale(Vector3.one, 0.5f))
                .Append(_startRoundText.transform.DOScale(Vector3.zero, 0.5f))
                .AppendCallback(() => _startRoundText.text = "1")
                .Append(_startRoundText.transform.DOScale(Vector3.one, 0.5f))
                .Append(_startRoundText.transform.DOScale(Vector3.zero, 0.5f));
        }
    }
}

