using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class PlayerJumpSystem : IEcsRunSystem
    {   
        private readonly RuntimeData _runtimeData;
        private readonly EcsFilter<GroundCheckComponent, JumpComponent, RigidbodyComponent, PlayerAnimatiorComponent, JumpEvent> _jumpPlayerFilter = null;

        public void Run()
        {
            foreach (var i in _jumpPlayerFilter)
            {
                ref var entity = ref _jumpPlayerFilter.GetEntity(i);

                if (_runtimeData.IsStopGame)
                {
                    entity.Del<JumpEvent>();
                    return;
                }

                ref var groundCheckComponent = ref _jumpPlayerFilter.Get1(i);
                ref var jumpComponent = ref _jumpPlayerFilter.Get2(i);
                ref var rigidbodyComponent = ref _jumpPlayerFilter.Get3(i);
                ref var playerAnimatiorComponent = ref _jumpPlayerFilter.Get4(i);

                ref var rigidbody = ref rigidbodyComponent.Rigidbody;

                if (groundCheckComponent.IsGrounded)
                {
                    Jump(ref rigidbody, ref jumpComponent, ref playerAnimatiorComponent);
                    groundCheckComponent.IsCanSecondJump = true;
                    entity.Get<PlayerUIUpdateRequest>().IsFirstJump = !groundCheckComponent.IsCanSecondJump;
                }
                else if (groundCheckComponent.IsCanSecondJump)
                {
                    Jump(ref rigidbody, ref jumpComponent, ref playerAnimatiorComponent);
                    groundCheckComponent.IsCanSecondJump = false;
                    entity.Get<PlayerUIUpdateRequest>().IsFirstJump = !groundCheckComponent.IsCanSecondJump;
                }

                entity.Del<JumpEvent>();
            }
        }

        private void Jump(
            ref Rigidbody2D rigidbody, 
            ref JumpComponent jumpComponent, 
            ref PlayerAnimatiorComponent playerAnimatiorComponent)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(0, jumpComponent.Force), ForceMode2D.Impulse);
            playerAnimatiorComponent.Animator.SetBool("IsJump", true);
            jumpComponent.JumpSound.Play();
        }
    }
}

