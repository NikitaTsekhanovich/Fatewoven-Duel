using System.Collections.Generic;
using MainMenuControllers.Store.Properties;
using PlayerData;
using SceneControllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenuControllers.Store
{
    public class StoreController : MonoBehaviour
    {
        [SerializeField] private GameObject _parentBoysItems;
        [SerializeField] private GameObject _parentGirlsItems;
        [SerializeField] private StoreItem _storeItem;
        [SerializeField] private AudioSource _purchaseSound;
        [SerializeField] private GameObject _nextStoreButton;
        [SerializeField] private GameObject _previousStoreButton;
        [SerializeField] private GameObject _boyTable;
        [SerializeField] private GameObject _girlTable;
        [SerializeField] private Image _background;
        [SerializeField] private Sprite _boyBackground;
        [SerializeField] private Sprite _girlBackground;

        private List<StoreItem> _storeBoysItems = new();
        private List<StoreItem> _storeGirlsItems = new();
        private int _currentCoins;
        private bool _isBoysStore;

        private void OnEnable()
        {
            SceneDataLoader.OnLoadStoreSkinsData += LoadStoreItems;
        }

        private void OnDisable()
        {
            SceneDataLoader.OnLoadStoreSkinsData -= LoadStoreItems;
        }

        public void LoadStoreItems()
        {
            _isBoysStore = true;
            _parentBoysItems.SetActive(true);
            _parentGirlsItems.SetActive(false);

            SetCurrentData(_parentBoysItems.transform, SkinsDataContainer.SkinBoysData, _storeBoysItems);
            SetCurrentData(_parentGirlsItems.transform, SkinsDataContainer.SkinGirlsData, _storeGirlsItems);
        }

        private void SetCurrentData<T>(Transform parentTransform, List<T> skinsData, List<StoreItem> currentSkinsData)
            where T : SkinData
        {
            for (var i = 0; i < skinsData.Count; i++)
            {
                var newItem = Instantiate(_storeItem, parentTransform);
                newItem.Init(skinsData[i].LockText, skinsData[i].Icon, i, BuyOrSelectItem, skinsData[i].TypeState);

                currentSkinsData.Add(newItem);
            }
        }

        public void BuyOrSelectItem(int index)
        {
            IItem currentItem;

            if (_isBoysStore) currentItem = SkinsDataContainer.SkinBoysData[index];
            else currentItem = SkinsDataContainer.SkinGirlsData[index];

            if (currentItem.TypeState == TypeStateStoreItem.Bought || currentItem.TypeState == TypeStateStoreItem.Selected)
            {
                SelectStoreItem(currentItem);
            }
        }

        private void SelectStoreItem(IItem currentItem)
        {            
            var chosenItemIndex = PlayerPrefs.GetInt(currentItem.IndexChosenItemKey);
            IItem previousItem;

            if (_isBoysStore)
            {
                previousItem = SkinsDataContainer.SkinBoysData[chosenItemIndex];
                SelectItem(previousItem, currentItem, chosenItemIndex, _storeBoysItems);
            }
            else
            {
                previousItem = SkinsDataContainer.SkinGirlsData[chosenItemIndex];
                SelectItem(previousItem, currentItem, chosenItemIndex, _storeGirlsItems);
            }
        }

        private void SelectItem(IItem previousItem, IItem currentItem, int chosenItemIndex, List<StoreItem> storeItems)
        {
            PlayerPrefs.SetInt(previousItem.StateItemKey, (int)TypeStateStoreItem.Bought);
            storeItems[chosenItemIndex].ChangeChosenState(false, TypeStateStoreItem.Bought);

            PlayerPrefs.SetInt(currentItem.IndexChosenItemKey, currentItem.Index);

            storeItems[currentItem.Index].ChangeChosenState(true, TypeStateStoreItem.Selected);
            PlayerPrefs.SetInt(currentItem.StateItemKey, (int)TypeStateStoreItem.Selected);
        }

        public void SwitchNextStore()
        {
            _background.sprite = _girlBackground;
            SwitchStore(true);
        }

        public void SwitchPreviousStore()
        {
            _background.sprite = _boyBackground;
            SwitchStore(false);
        }

        private void SwitchStore(bool isNextStore)
        {
            _nextStoreButton.SetActive(!isNextStore);
            _previousStoreButton.SetActive(isNextStore);
            _isBoysStore = !isNextStore;
            _parentBoysItems.SetActive(!isNextStore);
            _parentGirlsItems.SetActive(isNextStore);
            _boyTable.SetActive(!isNextStore);
            _girlTable.SetActive(isNextStore);
        }
    }
}

