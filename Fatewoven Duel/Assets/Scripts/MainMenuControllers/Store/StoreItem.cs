using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenuControllers.Store
{
    public class StoreItem : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _chooseIcon;
        [SerializeField] private TMP_Text _buttonText;
        private int _index;
        private Action<int> _onChooseItem;

        public void Init(string priceText, Sprite icon, int index, Action<int> OnChooseItem, TypeStateStoreItem typeState)
        {
            if (typeState == TypeStateStoreItem.NotBought) 
            {
                _buttonText.text = priceText;
            }
            
            _icon.sprite = icon;
            _index = index;
            _onChooseItem = OnChooseItem;
            
            if (typeState == TypeStateStoreItem.Selected)
                ChangeChosenState(true, typeState);
            else
                ChangeButtonText(typeState);
        }

        public void ChooseItem()
        {
            _onChooseItem.Invoke(_index);
        }

        public void ChangeChosenState(bool isChosen, TypeStateStoreItem typeState)
        {
            _chooseIcon.enabled = isChosen;
            ChangeButtonText(typeState);
        }

        public void ChangeButtonText(TypeStateStoreItem typeState)
        {
            if (typeState == TypeStateStoreItem.Selected)
            {
                _buttonText.text = "";
            }
            else if (typeState == TypeStateStoreItem.Bought)
            {
                _buttonText.text = "Select";
            }
        }
    }
}

