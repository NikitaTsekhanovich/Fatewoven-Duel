using GameControllers.Components;
using GameControllers.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class GroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GroundCheckComponent> _groundCheckFilter = null;

        public void Run()
        {
            foreach (var i in _groundCheckFilter)
            {
                ref var entity = ref _groundCheckFilter.GetEntity(i);
                ref var groundCheckComponent = ref _groundCheckFilter.Get1(i);
                var previousState = groundCheckComponent.IsGrounded;

                groundCheckComponent.IsGrounded = Physics2D.OverlapCircle(
                    groundCheckComponent.TransformCircle.position, 
                    groundCheckComponent.RadiusCircle, 
                    groundCheckComponent.GroundMask);

                if (previousState != groundCheckComponent.IsGrounded && groundCheckComponent.IsGrounded)
                {
                    entity.Get<PlayerUIUpdateRequest>().IsFirstJump = true;
                }
            }
        }
    }
}

