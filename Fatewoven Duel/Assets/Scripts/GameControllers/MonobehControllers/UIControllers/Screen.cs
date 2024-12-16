using UnityEngine;

namespace GameControllers.MonobehControllers.UIControllers
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverScreen;

        public void ChangeStateScreen(bool isActive)
        {
            _gameOverScreen.SetActive(isActive);
        }
    }
}

