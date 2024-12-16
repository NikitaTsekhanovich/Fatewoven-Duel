using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MainMenuControllers.Store
{
    public class SkinsDataContainer : MonoBehaviour
    {
        public static List<SkinBoyData> SkinBoysData { get; private set; }
        public static List<SkinGirlData> SkinGirlsData { get; private set; }

        public static void LoadSkinBoysData()
        {
            SkinBoysData = Resources.LoadAll<SkinBoyData>("ScriptableObjectData/SkinBoysData")
                .OrderBy(x => x.Index)
                .ToList();
        }

        public static void LoadSkinGirlsData()
        {
            SkinGirlsData = Resources.LoadAll<SkinGirlData>("ScriptableObjectData/SkinGirlsData")
                .OrderBy(x => x.Index)
                .ToList();
        }
    }
}

