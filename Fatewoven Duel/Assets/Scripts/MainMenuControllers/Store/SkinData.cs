using MainMenuControllers.Store.Properties;
using SceneControllers;
using UnityEngine;

namespace MainMenuControllers.Store
{
    public class SkinData : ScriptableObject, IItem
    {
        [SerializeField] protected int _index;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _lockText;
        [SerializeField] private SkinCharacter _skinCharacter;

        public int Index => _index;
        public Sprite Icon => _icon;
        public string LockText => _lockText;
        public SkinCharacter SkinCharacter => _skinCharacter;
        public virtual TypeStateStoreItem TypeState { get; }
        public virtual string StateItemKey { get; }
        public virtual string IndexChosenItemKey { get; }
    }
}

