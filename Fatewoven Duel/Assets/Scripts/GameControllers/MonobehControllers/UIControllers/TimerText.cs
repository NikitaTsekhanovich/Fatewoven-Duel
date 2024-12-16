using TMPro;
using UnityEngine;

namespace GameControllers.MonobehControllers.UIControllers
{
    public class TimerText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;

        public void UpdateTimerText(int time)
        {
            _timerText.text = $"Time: {time}";
        }
    }
}

