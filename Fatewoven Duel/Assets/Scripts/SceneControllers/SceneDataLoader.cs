using System;
using LevelsControllers;
using MainMenuControllers;
using MainMenuControllers.Store;
using MusicSystem;
using PlayerData;
using SceneControllers.Properties;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneControllers
{
    public class SceneDataLoader : MonoBehaviour
    {
        private GameSettings _gameSettings;

        public static Action OnLoadStoreSkinsData;
        public static Action<GameSettings> OnInitEcsStartup;
        public static SceneDataLoader Instance;

        private void Start() 
        {             
            if (Instance == null) 
                Instance = this;  
            else 
                Destroy(this);   
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            BlockSwitcher.OnStashMatchSettings += StashMatchSettings;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            BlockSwitcher.OnStashMatchSettings -= StashMatchSettings;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name == "MainMenu")
            {
                CheckFirstLaunch();
                SkinsDataContainer.LoadSkinBoysData();
                SkinsDataContainer.LoadSkinGirlsData();
                LevelDataContainer.LoadLevelData();
                OnLoadStoreSkinsData.Invoke();
                BackgroundMusicSwitch.Instance.OnMenuBackgroundMusic();
            }
            else if (scene.name == "Game")
            {
                OnInitEcsStartup.Invoke(_gameSettings);
                BackgroundMusicSwitch.Instance.OnGameBackgroundMusic();
            }
        }

        private void StashMatchSettings(GameSettings gameSettings)
        {
            if (gameSettings.SkinBoyData == null)
                gameSettings.SkinBoyData = SkinsDataContainer.
                    SkinBoysData[PlayerPrefs.GetInt(StateStoreItemDataKeys.IndexChosenSkinBoyKey)].SkinCharacter;
            if (gameSettings.SkinGirlData == null)
                gameSettings.SkinGirlData = SkinsDataContainer.
                    SkinGirlsData[PlayerPrefs.GetInt(StateStoreItemDataKeys.IndexChosenSkinGirlKey)].SkinCharacter;
            
            _gameSettings = gameSettings;
        }

        private void CheckFirstLaunch()
        {
            if (PlayerPrefs.GetInt(PlayerDataKeys.IsFirstLaunchGameKey) == (int)TypeLaunch.IsFirst)
            {
                PlayerPrefs.SetInt($"{PlayerDataKeys.LevelOpenKey}{0}", (int)ModeLevel.Unlock);
                PlayerPrefs.SetInt(PlayerDataKeys.IsFirstLaunchGameKey, (int)TypeLaunch.IsNotFirst);
                PlayerPrefs.SetInt($"{StateStoreItemDataKeys.StateSkinBoyKey}{0}", (int)TypeStateStoreItem.Selected);
                PlayerPrefs.SetInt(StateStoreItemDataKeys.IndexChosenSkinBoyKey, 0);
                PlayerPrefs.SetInt($"{StateStoreItemDataKeys.StateSkinGirlKey}{0}", (int)TypeStateStoreItem.Selected);
                PlayerPrefs.SetInt(StateStoreItemDataKeys.IndexChosenSkinGirlKey, 0);
            }
        }
    }
}
