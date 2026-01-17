
namespace HW_31
{
    public class GameModeFactory
    {
        private LevelConfig _levelConfig;
        private EnemyHolder _enemyHolder;
        private EvilCactusSpawner _evilCactusSpawner;
        private ConditionsFactory _conditionsFactory;
        private GameView _gameView;

        public GameModeFactory(LevelConfig levelConfig, EnemyHolder enemyHolder, EvilCactusSpawner evilCactusSpawner, ConditionsFactory conditionsFactory, GameView gameView)
        {
            _levelConfig = levelConfig;
            _enemyHolder = enemyHolder;
            _evilCactusSpawner = evilCactusSpawner;
            _conditionsFactory = conditionsFactory;
            _gameView = gameView;
        }

        public GameMode CreateGameMode(Character character)
        {
            ICondition victoryCondition = _conditionsFactory.CreateVictoryConditions(_levelConfig, _enemyHolder);
            ICondition defeatCondition = _conditionsFactory.CreateDefeatConditions(_levelConfig, _enemyHolder, character);

            GameMode gameMode = new GameMode(_levelConfig, _enemyHolder, _evilCactusSpawner, victoryCondition, defeatCondition);

            _gameView.Initialize(_enemyHolder, gameMode);

            return gameMode;
        }
    }
}
