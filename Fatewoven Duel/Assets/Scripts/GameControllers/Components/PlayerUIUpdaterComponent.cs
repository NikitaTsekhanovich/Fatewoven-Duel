using UnityEngine;
using System;
using UnityEngine.UI;

namespace GameControllers.Components
{
    [Serializable]
    public struct PlayerUIUpdaterComponent
    {
        public Image JumpButtonImage;
        public Sprite FirstJumpSprite;
        public Sprite SecondJumpSprite;
    }
}

