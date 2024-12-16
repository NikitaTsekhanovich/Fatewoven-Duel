using GameControllers.Components.Events;
using GameControllers.Ecs;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.MonobehControllers.UIControllers
{
    public class InputControl : MonoBehaviour
    {
        [SerializeField] private EntityReference _entityReferencePlayer;

        public void ClickJump()
        {
            _entityReferencePlayer.Entity.Get<JumpEvent>();
        }

        public void ClickAttack()
        {
            _entityReferencePlayer.Entity.Get<AttackEvent>();
        }
    }
}

