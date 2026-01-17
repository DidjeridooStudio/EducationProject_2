using System;

namespace HW_31
{
    public class GameMode
    {
        public event Action Victory;
        public event Action Defeat;

        private LevelConfig _levelConfig;
        private EnemyHolder _enemyHolder;
        private EvilCactusSpawner _enemySpawner;

        private ICondition _victoryCondition;
        private ICondition _defeatCondition;

        private bool _isRunning;

        public GameMode(
            LevelConfig levelConfig,
            EnemyHolder enemyHolder,
            EvilCactusSpawner enemySpawner,
            ICondition victoryCondition,
            ICondition defeatCondition)
        {
            _levelConfig = levelConfig;
            _enemyHolder = enemyHolder;
            _enemySpawner = enemySpawner;
            _victoryCondition = victoryCondition;
            _defeatCondition = defeatCondition;
        }

        public void Start()
        {
            _isRunning = true;

            _enemySpawner.SpawnEntity(_levelConfig.EnemiesCooldown);
        }

        public void Update(float deltatime)
        {
            if(_isRunning == false)
                return;

            if (_victoryCondition.Completed())
            {
                ProcessVictory();
                return;
            }

            if(_defeatCondition.Completed())
                ProcessDefeat();

        }

        private void ProcessVictory()
        {
            ProcessEndGame();
            Victory?.Invoke();
        }

        private void ProcessDefeat()
        {
            ProcessEndGame();
            Defeat?.Invoke();
        }

        private void ProcessEndGame()
        {
            _isRunning = false;

            _enemySpawner.StopSpawn();

            foreach (EvilCactus evilCactus in _enemyHolder.EvilCacti)
                evilCactus.Destroy();

            _enemyHolder.EvilCacti.Clear();
        }
    }
}
