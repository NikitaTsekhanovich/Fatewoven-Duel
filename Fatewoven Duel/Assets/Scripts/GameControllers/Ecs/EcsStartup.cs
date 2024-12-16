using System.Collections;
using GameControllers.Data;
using GameControllers.MonobehControllers;
using GameControllers.MonobehControllers.UIControllers;
using GameControllers.Systems;
using GameControllers.Systems.Initializers;
using Leopotam.Ecs;
using SceneControllers;
using SceneControllers.Properties;
using TMPro;
using UnityEngine;
using Voody.UniLeo;

namespace GameControllers.Ecs
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private UIContainer _uiContainer;
        [SerializeField] private PlayerSpawnData _playerSpawnData;
        [SerializeField] private SoundsContainer _soundsContainer;
        [SerializeField] private TMP_Text _firstPlayerDialog;
        [SerializeField] private TMP_Text _secondPlayerDialog;
        [SerializeField] private GameObject _dialogueWindow;
        private EcsWorld _world;
        private EcsSystems _systems;
        private bool _isStarted = true;

        private void OnEnable()
        {
            SceneDataLoader.OnInitEcsStartup += InitEcsWorld;
        }

        private void OnDisable()
        {
            SceneDataLoader.OnInitEcsStartup -= InitEcsWorld;
        }

        public void InitEcsWorld(GameSettings gameSettings)
        {
            if (gameSettings.ModeGame == ModeGame.SinglePlayer)
                StartCoroutine(WaitFrame());
            
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();

            var runtimeData = new RuntimeData();
            runtimeData.ModeGame = gameSettings.ModeGame;
            runtimeData.PlayerType = gameSettings.PlayerType;
            runtimeData.SkinBoyData = gameSettings.SkinBoyData;
            runtimeData.SkinGirlData = gameSettings.SkinGirlData;
            runtimeData.TimeRound = gameSettings.TimeRound;
            runtimeData.NumberRounds = gameSettings.NumberRounds;
            runtimeData.IndexLevel = gameSettings.IndexLevel;
            runtimeData.DelayAttackAI = gameSettings.DelayAttackAI;
            runtimeData.DelayJumpAI = gameSettings.DelayJumpAI;
            
            StartDialogue(gameSettings.PlayerDialogue, gameSettings.EnemyDialogue, gameSettings.ModeGame);

            AddInjections(runtimeData);
            AddOneFrames();
            AddSystems();

            _systems.Init();
        }

        private IEnumerator WaitFrame()
        {
            yield return new WaitForEndOfFrame();
            _isStarted = false;
        }

        private void AddInjections(RuntimeData runtimeData)
        {
            _systems
                .Inject(runtimeData)
                .Inject(_soundsContainer)
                .Inject(_playerSpawnData)
                .Inject(_uiContainer)
                .Inject(_gameData);
        }

        private void AddSystems()
        {
            _systems
                .Add(new GameInitializeSystem())
                .Add(new SpawnPlayerSystem())
                .Add(new EntityInitializeSystem())
                .Add(new SkinPlayerSystem())
                .Add(new AITacticSystem())
                .Add(new GroundCheckSystem())
                .Add(new PlayerJumpSystem())
                .Add(new PlayerUIUpdaterSystem())
                .Add(new MovementSystem())
                .Add(new AttackSystem())
                .Add(new DestroyEntitySystem())
                .Add(new SinglePlayerScoreSystem())
                .Add(new ScoreSystem())
                .Add(new TimerSystem())
                .Add(new BallAnimationSystem())
                .Add(new RoundsSystem())
                .Add(new RestartRoundSystem())
                .Add(new RestartPositionEntitySystem())
                .Add(new GameOverSystem());
        }

        private void AddOneFrames()
        {
            // _systems
            //     .OneFrame<SpawnGameLocationEvent>();
        }

        private void StartDialogue(string firstPlayerDialog, string secondPlayerDialog, ModeGame modeGame)
        {
            if (modeGame == ModeGame.SinglePlayer)
            {
                _firstPlayerDialog.text = firstPlayerDialog;
                _secondPlayerDialog.text = secondPlayerDialog;
            }
            else
            {
                _dialogueWindow.SetActive(false);
                ClickStartGame();
            }
        }

        public void ClickStartGame()
        {
            _isStarted = true;
        }

        private void Update()
        {
            if (_isStarted)
                _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null) return;

            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}

