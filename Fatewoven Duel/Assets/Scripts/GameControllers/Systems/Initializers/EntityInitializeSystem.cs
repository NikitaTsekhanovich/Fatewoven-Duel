using GameControllers.Components.Requests;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems.Initializers
{
    public class EntityInitializeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InitializeEntityRequest> _initEntityFilter = null;
        
        public void Run()
        {
            foreach (var i in _initEntityFilter)
            {
                ref var entity = ref _initEntityFilter.GetEntity(i);
                ref var request = ref _initEntityFilter.Get1(i);

                request.EntityReference.Entity = entity;
                entity.Del<InitializeEntityRequest>();
            }
        }
    }
}

