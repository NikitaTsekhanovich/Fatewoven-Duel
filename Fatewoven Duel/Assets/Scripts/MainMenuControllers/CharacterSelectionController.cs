using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenuControllers
{
    public class CharacterSelectionController : MonoBehaviour
    {
        [SerializeField] private Image _iconBoy;
        [SerializeField] private Image _iconGirl;
        [SerializeField] private TMP_Text _boyButtonText;
        [SerializeField] private TMP_Text _girlButtonText;
        [SerializeField] private Image _boyButtonImage;
        [SerializeField] private Image _girlButtonImage;
        [SerializeField] private Sprite _emptyButtonSprite;
        [SerializeField] private Sprite _selectedButtonSprite;
        [SerializeField] private GameObject _companyBoyBlock;
        [SerializeField] private GameObject _companyGirlBlock;
        private Vector2 _sizeChosenIcon = new Vector2(50, 50);
        private Vector2 _sizeUnchosenIcon = new Vector2(0, 0);
        private bool _isChosenBoy;
        private bool _isChosenGirl;

        private void Start()
        {
            ClickChooseBoy();
        }

        public void ClickChooseBoy()
        {
            if (_isChosenBoy)
                SetCharacter(_companyBoyBlock);

            ChooseCharacter(
                _iconBoy, 
                _iconGirl, 
                _boyButtonText,
                _girlButtonText,
                _boyButtonImage,
                _girlButtonImage,
                ref _isChosenBoy,
                ref _isChosenGirl);
        }

        public void ClickChooseGirl()
        {
            if (_isChosenGirl)
                SetCharacter(_companyGirlBlock);

            ChooseCharacter(
                _iconGirl,
                _iconBoy, 
                _girlButtonText,
                _boyButtonText,
                _girlButtonImage,
                _boyButtonImage,
                ref _isChosenGirl,
                ref _isChosenBoy);
        }

        private void SetCharacter(GameObject company)
        {
            company.SetActive(true);
        }

        private void ChooseCharacter(
            Image iconChosen, 
            Image iconUnchosen, 
            TMP_Text buttonTextChosen,
            TMP_Text buttonTextUnchosen,
            Image buttonImageChosen,
            Image buttonImageUnchosen,
            ref bool isChosenCharacter,
            ref bool isUncurrentCharacter)
        {
            iconChosen.rectTransform.sizeDelta = _sizeChosenIcon;
            iconUnchosen.rectTransform.sizeDelta = _sizeUnchosenIcon;
            buttonTextChosen.text = "Start a company";
            buttonTextUnchosen.text = "Select";
            buttonImageChosen.sprite = _selectedButtonSprite;
            buttonImageUnchosen.sprite = _emptyButtonSprite;
            isChosenCharacter = true;
            isUncurrentCharacter = false;
        }
    }
}

