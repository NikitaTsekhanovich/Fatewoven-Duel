using GameControllers.Components;
using GameControllers.Components.Events;
using GameControllers.Components.Requests;
using GameControllers.Data;
using GameControllers.MonobehControllers.UIControllers;
using Leopotam.Ecs;

namespace GameControllers.Systems
{
    public class RoundsSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsWorld _world;
        private readonly RuntimeData _runtimeData;
        private readonly UIContainer _uiContainer;
        private readonly EcsFilter<RoundsComponent> _roundsFilter = null;
        private readonly EcsFilter<RoundsComponent, EndRoundEvent> _endRoundFilter = null;

        public void Init()
        {
            foreach (var i in _roundsFilter)
            {
                _uiContainer.RoundsUIUpdater.Init(_roundsFilter.Get1(i).NumberRounds);
            }
        }

        public void Run()
        {
            foreach (var i in _endRoundFilter)
            {
                ref var entity = ref _endRoundFilter.GetEntity(i);
                ref var roundsComponent = ref _endRoundFilter.Get1(i);
                ref var numberWinsFirstPlayer = ref roundsComponent.NumberWinsFirstPlayer;
                ref var numberWinsSecondPlayer = ref roundsComponent.NumberWinsSecondPlayer;
                ref var numberRounds = ref roundsComponent.NumberRounds;

                var scoreFirstPlayer = _runtimeData.ScorePlayer1;
                var scoreSecondPlayer = _runtimeData.ScorePlayer2;
                TypeEndRound typeEndRound;

                if (scoreFirstPlayer > scoreSecondPlayer)
                {
                    typeEndRound = TypeEndRound.FirstPlayerWin;
                    numberWinsFirstPlayer++;
                }
                else if (scoreFirstPlayer < scoreSecondPlayer)
                {
                    typeEndRound = TypeEndRound.SecondPlayerWin;
                    numberWinsSecondPlayer++;
                }
                else
                {
                    typeEndRound = TypeEndRound.Draw;
                    numberWinsFirstPlayer++;
                    numberWinsSecondPlayer++;
                }

                _uiContainer.RoundsUIUpdater.UpdateRounds(typeEndRound);

                if ((numberWinsFirstPlayer == numberRounds / 2 && numberWinsSecondPlayer == numberRounds / 2) ||
                    (numberWinsFirstPlayer >= numberRounds / 2) || (numberWinsSecondPlayer >= numberRounds / 2))
                {
                    var gameOverRequest = new GameOverRequest();
                    gameOverRequest.NumberWinFirstPlayer = numberWinsFirstPlayer;
                    gameOverRequest.NumberWinSecondPlayer = numberWinsSecondPlayer;

                    _world.NewEntity().Replace(gameOverRequest);
                }
                else
                {
                    _world.NewEntity().Get<RestartRoundEvent>();
                }

                entity.Del<EndRoundEvent>();
            }
        }
    }
}

