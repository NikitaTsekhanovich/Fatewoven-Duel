using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Data;
using GameControllers.MonobehControllers.UIControllers;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class TimerSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly RuntimeData _runtimeData;
        private readonly UIContainer _uiContainer;
        private readonly EcsFilter<TimerComponent> _timerFilter = null;

        public void Init()
        {
            foreach (var i in _timerFilter)
            {
                ref var timerComponent = ref _timerFilter.Get1(i);
                ref var currentTimer = ref timerComponent.CurrentTime;
                ref var startTime = ref timerComponent.StartTime;

                currentTimer = startTime;

                _uiContainer.TimerText.UpdateTimerText((int)currentTimer);
            }
        }

        public void Run()
        {
            foreach (var i in _timerFilter)
            {
                if (_runtimeData.IsStopGame) return;

                ref var timerComponent = ref _timerFilter.Get1(i);
                ref var currentTimer = ref timerComponent.CurrentTime;
                ref var isStopTime = ref timerComponent.IsStopTime;

                if (isStopTime) return;

                currentTimer -= Time.deltaTime;

                _uiContainer.TimerText.UpdateTimerText((int)currentTimer);

                if (currentTimer <= 0)
                {
                    ref var entity = ref _timerFilter.GetEntity(i);

                    isStopTime = true;
                    _runtimeData.RoundsEntity.Get<EndRoundEvent>();
                }
            }
        }
    }
}

