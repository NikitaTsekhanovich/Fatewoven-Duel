using System;
using UnityEngine;

namespace SceneControllers
{
    [Serializable]
    public class SkinCharacter
    {
        public Sprite HeadSprite;
        public Sprite BodySprite;
        public Sprite HandSprite;

        public SkinCharacter(Sprite headSprite, Sprite bodySprite, Sprite handSprite)
        {
            HeadSprite = headSprite;
            BodySprite = bodySprite;
            HandSprite = handSprite;
        }
    }
}
