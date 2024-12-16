using UnityEngine;

namespace MainMenuControllers.Store.Properties
{
    public interface IItem
    {
        public int Index { get; }
        public Sprite Icon { get; }
        public string LockText { get; }
        public TypeStateStoreItem TypeState { get; }
        public string StateItemKey { get; }
        public string IndexChosenItemKey { get; }
    }
}

