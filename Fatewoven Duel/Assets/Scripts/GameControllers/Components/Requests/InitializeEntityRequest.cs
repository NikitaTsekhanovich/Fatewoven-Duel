using System;
using GameControllers.Ecs;

namespace GameControllers.Components.Requests
{
    [Serializable]
    public struct InitializeEntityRequest
    {
        public EntityReference EntityReference;
    }
}

