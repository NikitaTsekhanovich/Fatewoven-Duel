using DG.Tweening;
using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Components.Tags;
using GameControllers.Data;
using GameControllers.Ecs;
using GameControllers.MonobehControllers.UIControllers;
using Leopotam.Ecs;
using UnityEngine;

namespace GameControllers.Systems
{
    public class RestartRoundSystem : IEcsRunSystem
    {
        private readonly RuntimeData _runtimeData;
        private readonly UIContainer _uiContainer;
        private readonly EcsFilter<RestartRoundEvent> _restartRoundFilter = null;
        private readonly EcsFilter<FirstPlayerTag> _firstPlayerFilter = null;
        private readonly EcsFilter<SecondPlayerTag> _secondPlayerFilter = null;

        public void Run()
        {
            foreach (var i in _restartRoundFilter)
            {
                ref var entity = ref _restartRoundFilter.GetEntity(i);

                _runtimeData.IsStopGame = true;

                RestartScore();
                DestroyGameEntities();
                RestartTimer();
                RestartPositionPlayers();

                _uiContainer.StartRoundText.StartAnimationText();
                _uiContainer.TimerText.UpdateTimerText(_runtimeData.TimeRound);

                DOTween.Sequence()
                    .AppendInterval(3f)
                    .AppendCallback(() => _runtimeData.IsStopGame = false);

                entity.Del<RestartRoundEvent>();
            }
        }

        private void RestartPositionPlayers()
        {
            foreach (var i in _firstPlayerFilter)
            {
                ref var entity = ref _firstPlayerFilter.GetEntity(i);
                entity.Get<RestartPositionEntityEvent>();
            }
            
            foreach (var i in _secondPlayerFilter)
            {
                ref var entity = ref _secondPlayerFilter.GetEntity(i);
                entity.Get<RestartPositionEntityEvent>();
            }
        }

        private void DestroyGameEntities()
        {
            var gameEntities = GameObject.FindGameObjectsWithTag("GameEntities");

            for (var i = gameEntities.Length - 1; i >= 0; i--)
            {
                var entityReference = gameEntities[i].GetComponent<EntityReference>();
                entityReference.Entity.Destroy();
                Object.Destroy(gameEntities[i]);
            }
        }

        private void RestartScore()
        {
            _runtimeData.ScorePlayer1 = 0;
            _runtimeData.ScorePlayer2 = 0;
            _uiContainer.ScorePlayersText.UpdateScorePlayer1(0);
            _uiContainer.ScorePlayersText.UpdateScorePlayer2(0);
        }

        private void RestartTimer()
        {
            var timerComponent = new TimerComponent();
            timerComponent.CurrentTime = _runtimeData.TimeRound;
            timerComponent.StartTime = 0;

            _runtimeData.TimerEntity.Replace(timerComponent);
        }
    }
}

