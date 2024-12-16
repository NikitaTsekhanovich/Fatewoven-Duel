using GameControllers.EntitesTypes;
using UnityEngine;

namespace GameControllers.Components.Requests
{
    public struct IncreaseScoreRequest
    {
        [HideInInspector] public GameEntityType TypeDeadPlayer;
    }
}

