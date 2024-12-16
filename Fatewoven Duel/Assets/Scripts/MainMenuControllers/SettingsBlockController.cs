using UnityEngine;

namespace MainMenuControllers
{
    public class SettingsBlockController : MonoBehaviour
    {
        [SerializeField] private GameObject _musicButton;
        [SerializeField] private GameObject _soundEffectsButton;
        private bool _isOpenSettings;

        public void ClickChangeStateSettingsBlock()
        {
            _isOpenSettings = !_isOpenSettings;

            _musicButton.SetActive(_isOpenSettings);
            _soundEffectsButton.SetActive(_isOpenSettings);
        }
    }
}

