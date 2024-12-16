using UnityEngine;

namespace MusicSystem
{
    public class BackgroundMusicSwitch : MonoBehaviour
    {
        [SerializeField] private AudioSource _menuMusic;
        [SerializeField] private AudioSource _gameMusic;

        public static BackgroundMusicSwitch Instance;

        private void Awake() 
        {
            if (Instance == null)
                Instance = this; 
            else 
                Destroy(this);  
        }

        public void OnMenuBackgroundMusic()
        {
            _gameMusic.Stop();
            _menuMusic.Play();
        }

        public void OnGameBackgroundMusic()
        {
            _menuMusic.Stop();
            if (!_gameMusic.isPlaying)
                _gameMusic.Play();
        }
    }
}

