using GameControllers.Components.Requests;
using GameControllers.Data;
using GameControllers.EntitesTypes;
using GameControllers.MonobehControllers.UIControllers;
using Leopotam.Ecs;

namespace GameControllers.Systems
{
    public class ScoreSystem : IEcsRunSystem
    {
        private readonly RuntimeData _runtimeData;
        private readonly UIContainer _uiContainer;
        private readonly EcsFilter<IncreaseScoreRequest> _scoreRequestFilter = null;

        public void Run()
        {
            foreach (var j in _scoreRequestFilter)
            {
                ref var entity = ref _scoreRequestFilter.GetEntity(j);
                ref var increaseScoreRequest = ref _scoreRequestFilter.Get1(j);

                if (increaseScoreRequest.TypeDeadPlayer == GameEntityType.FirstPlayer)
                {
                    _runtimeData.ScorePlayer2++;
                    _uiContainer.ScorePlayersText.UpdateScorePlayer2(_runtimeData.ScorePlayer2);
                }
                if (increaseScoreRequest.TypeDeadPlayer == GameEntityType.SecondPlayer)
                {
                    _runtimeData.ScorePlayer1++;
                    _uiContainer.ScorePlayersText.UpdateScorePlayer1(_runtimeData.ScorePlayer1);
                }

                entity.Del<IncreaseScoreRequest>();
            }
        }
    }
}

