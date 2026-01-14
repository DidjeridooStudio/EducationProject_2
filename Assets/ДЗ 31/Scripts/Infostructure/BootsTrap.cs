using UnityEngine;

namespace HW_31
{
    public class BootsTrap : MonoBehaviour
    {
        [SerializeField] private GameView _gameView;

        private CharactersControllersUpdateService _controllersUpdateService;
        private GameplayCircle _gameplayCircle;

        private void Awake()
        {
            LevelConfig levelConfig = Resources.Load<LevelConfig>("Configs/LevelConfig");

            _controllersUpdateService = new CharactersControllersUpdateService();
            ControllersFactory controllersFactory = new ControllersFactory();
            CharacterFactory characterFactory = new CharacterFactory(_controllersUpdateService, controllersFactory);

            EnemyHolder enemyHolder = new EnemyHolder();
            EnemiesFactory enemiesFactory = new EnemiesFactory(enemyHolder);

            EvilCactusSpawner evilCactusSpawner =  new EvilCactusSpawner(enemiesFactory, levelConfig.EvilCactusConfig, levelConfig.EnemiesSpawnPoints, this);

            _gameplayCircle = new GameplayCircle(characterFactory, levelConfig, enemyHolder, evilCactusSpawner, _gameView);
            _gameplayCircle.Prepare();
            _gameplayCircle.Launch();
        }

        private void Update()
        {
            _controllersUpdateService?.Update(Time.deltaTime);
            _gameplayCircle?.Update(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _gameplayCircle?.Dispose();
        }
    }
}
