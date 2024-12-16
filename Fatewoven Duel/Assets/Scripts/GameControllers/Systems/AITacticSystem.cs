using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class AITacticSystem : IEcsRunSystem
    {
        private RuntimeData _runtimeData;
        private readonly EcsFilter<AITacticComponent> _aiTacticFilter = null;
        private bool isFirstAttack = true;

        public void Run()
        {
            foreach (var i in _aiTacticFilter)
            {
                ref var entity = ref _aiTacticFilter.GetEntity(i);
                ref var aiTacticComponent = ref _aiTacticFilter.Get1(i);
                ref var currentDelayAttack = ref aiTacticComponent.CurrentDelayAttack;
                ref var currentDelayJump = ref aiTacticComponent.CurrentDelayJump;
                
                if (isFirstAttack)
                {
                    currentDelayAttack = _runtimeData.DelayAttackAI + AITacticComponent.AdditionalDelayAttack;
                    isFirstAttack = false;
                }
                
                currentDelayAttack += Time.deltaTime;
                currentDelayJump += Time.deltaTime;

                if (currentDelayAttack >= _runtimeData.DelayAttackAI + AITacticComponent.AdditionalDelayAttack)
                {
                    currentDelayAttack = 0;
                    entity.Get<AttackEvent>();
                }

                if (currentDelayJump >= _runtimeData.DelayJumpAI)
                {
                    currentDelayJump = Random.Range(0, 1.5f);
                    entity.Get<JumpEvent>();
                }
            }
        }
    }
}

