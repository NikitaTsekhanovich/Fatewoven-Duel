using UnityEngine;

namespace MainMenuControllers.Store
{
    [CreateAssetMenu(fileName = "SkinGirlData", menuName = "Skins data/ Skin girl data")]
    public class SkinGirlData : SkinData
    {
        public override TypeStateStoreItem TypeState
        {
            get
            {
                return (TypeStateStoreItem)PlayerPrefs.GetInt($"{StateStoreItemDataKeys.StateSkinGirlKey}{_index}");
            }
        }
        public override string StateItemKey => $"{StateStoreItemDataKeys.StateSkinGirlKey}{_index}";
        public override string IndexChosenItemKey => StateStoreItemDataKeys.IndexChosenSkinGirlKey;
    }
}

