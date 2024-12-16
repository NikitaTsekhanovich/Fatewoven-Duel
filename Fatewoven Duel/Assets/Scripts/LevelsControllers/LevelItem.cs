using System;
using UnityEngine;
using UnityEngine.UI;

namespace LevelsControllers
{
    public class LevelItem : MonoBehaviour
    {
        [SerializeField] private Image _iconLevel;
        [SerializeField] private Sprite _iconOpenLevel;
        [SerializeField] private Sprite _iconCloseLevel;
        [SerializeField] private Button _playButton;
        [SerializeField] private Sprite _iconPlay;
        [SerializeField] private Sprite _iconLock;
        private int _indexLevel;
        private Action<int> _onChooseLevel;

        public void InitItem(ModeLevel modeLevel, int indexLevel, Action<int> onChooseLevel)
        {
            _indexLevel = indexLevel;
            _onChooseLevel = onChooseLevel;
            
            if (modeLevel == ModeLevel.Lock)
            {
                _playButton.interactable = false;
                _playButton.image.sprite = _iconLock;
                _iconLevel.sprite = _iconCloseLevel;
            }
            else if (modeLevel == ModeLevel.Unlock)
            {
                _playButton.interactable = true;
                _playButton.image.sprite = _iconPlay;
                _iconLevel.sprite = _iconOpenLevel;
            }
        }

        public void ClickPlay()
        {
            _onChooseLevel.Invoke(_indexLevel);
        }
    }
}
