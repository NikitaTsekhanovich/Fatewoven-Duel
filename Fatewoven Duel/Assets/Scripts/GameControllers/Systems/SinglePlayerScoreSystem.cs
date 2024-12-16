using GameControllers.Components;
using GameControllers.Components.Events;
using Leopotam.Ecs;
using PlayerData;
using UnityEngine;

namespace GameControllers.Systems
{
    public class SinglePlayerScoreSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<SinglePlayerScoreComponent> _singlePlayerScoreFilter = null;
        private readonly EcsFilter<SinglePlayerScoreComponent, IncreaseSinglePlayerScoreEvent> _increaseSinglePlayerScoreFilter = null;

        public void Init()
        {
            foreach (var i in _singlePlayerScoreFilter)
            {
                ref var singlePlayerScoreComponent = ref _singlePlayerScoreFilter.Get1(i);
                ref var bestScore = ref singlePlayerScoreComponent.BestScore;

                bestScore = PlayerPrefs.GetInt(PlayerDataKeys.BestScoreKey);
            }
        }

        public void Run()
        {
            foreach (var i in _increaseSinglePlayerScoreFilter)
            {
                ref var entity = ref _increaseSinglePlayerScoreFilter.GetEntity(i);
                ref var singlePlayerScoreComponent = ref _singlePlayerScoreFilter.Get1(i);
                ref var bestScore = ref singlePlayerScoreComponent.BestScore;
                ref var currentScore = ref singlePlayerScoreComponent.CurrentScore;

                currentScore++;

                if (currentScore > bestScore)
                {
                    bestScore = currentScore;
                    PlayerPrefs.SetInt(PlayerDataKeys.BestScoreKey, bestScore);
                }

                entity.Del<IncreaseSinglePlayerScoreEvent>();
            }
        }
    }
}

