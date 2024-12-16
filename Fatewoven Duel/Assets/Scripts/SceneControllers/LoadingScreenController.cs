using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneControllers
{
    public class LoadingScreenController : MonoBehaviour
    {
        [SerializeField] private GraphicRaycaster _loadingScreenBlockClick;
        [SerializeField] private Image _background;
        [SerializeField] private TMP_Text _loadingText;
        [SerializeField] private Image _logo;
        [SerializeField] private Image _characters;
        private Coroutine _loadingTextAnimation;
        private const float delayFadeAnimation = 0.7f;

        public static LoadingScreenController Instance;

        private void Start() 
        {
            if (Instance == null)
            { 
                Instance = this; 
            } 
            else 
            { 
                Destroy(this);  
            }
        }
        
        public void ChangeScene(string nameScene)
        {
            Time.timeScale = 1f;

            _loadingScreenBlockClick.enabled = true;
            StartAnimationFade(nameScene);
        }

        private void StartAnimationFade(string nameScene)
        {
            _loadingTextAnimation = StartCoroutine(StartLoadingTextAnimation());
            _loadingText.DOFade(1f, delayFadeAnimation);
            _logo.DOFade(1f, delayFadeAnimation);
            _characters.DOFade(1f, delayFadeAnimation);

            DOTween.Sequence()
                .Append(_background.DOFade(1f, delayFadeAnimation))
                .AppendInterval(1.5f)
                .AppendCallback(() => LoadScene(nameScene))
                .AppendInterval(0.3f)
                .OnComplete(() => EndAnimationFade());
        }

        private void LoadScene(string nameScene)
        {
            SceneManager.LoadSceneAsync(nameScene);
        }

        private void EndAnimationFade()
        {        
            _logo.DOFade(0f, delayFadeAnimation);
            _loadingText.DOFade(0f, delayFadeAnimation);
            _characters.DOFade(0f, delayFadeAnimation);

            DOTween.Sequence()
                .Append(_background.DOFade(0f, delayFadeAnimation))
                .AppendCallback(() => StopCoroutine(_loadingTextAnimation))
                .AppendCallback(() => _loadingScreenBlockClick.enabled = false)
                .AppendCallback(() => Time.timeScale = 1f);
        }

        private IEnumerator StartLoadingTextAnimation()
        {
            while (true)
            {
                _loadingText.text = $"Loading.";
                yield return new WaitForSeconds(0.3f);

                _loadingText.text = $"Loading..";
                yield return new WaitForSeconds(0.3f);

                _loadingText.text = $"Loading...";
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}

