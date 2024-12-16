using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LevelsControllers
{
    public class LevelDataContainer : MonoBehaviour
    {
        public static List<LevelData> LevelData { get; private set; }

        public static void LoadLevelData()
        {
            LevelData = Resources.LoadAll<LevelData>("ScriptableObjectData/LevelData")
                .OrderBy(x => x.Index)
                .ToList();
        }
    }
}
