using GameControllers.EntitesTypes;
using UnityEngine;

namespace GameControllers.Components.Requests
{
    public struct RespawnPlayerRequest
    {
        [HideInInspector] public GameEntityType PlayerType;
    }
}

