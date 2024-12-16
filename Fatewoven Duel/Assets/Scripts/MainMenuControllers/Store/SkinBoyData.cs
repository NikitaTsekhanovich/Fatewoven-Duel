using UnityEngine;


namespace MainMenuControllers.Store
{
    [CreateAssetMenu(fileName = "SkinBoyData", menuName = "Skins data/ Skin boy data")]
    public class SkinBoyData : SkinData
    {
        public override TypeStateStoreItem TypeState
        {
            get
            {
                return (TypeStateStoreItem)PlayerPrefs.GetInt($"{StateStoreItemDataKeys.StateSkinBoyKey}{_index}");
            }
        }
        public override string StateItemKey => $"{StateStoreItemDataKeys.StateSkinBoyKey}{_index}";
        public override string IndexChosenItemKey => StateStoreItemDataKeys.IndexChosenSkinBoyKey;
    }
}

