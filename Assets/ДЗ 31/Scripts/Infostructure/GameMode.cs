using System;
using Object = UnityEngine.Object;

namespace HW_31
{
    public class GameMode
    {
        public event Action Victory;
        public event Action Defeat;

        private LevelConfig _levelConfig;
        private EnemyHolder _enemyHolder;
        private Character _character;
        private EvilCactusSpawner _enemySpawner;

        private float _currentTimeToWin;
        private bool _isRunning;

        public GameMode(LevelConfig levelConfig, EnemyHolder enemyHolder, Character character, EvilCactusSpawner enemySpawner)
        {
            _levelConfig = levelConfig;
            _enemyHolder = enemyHolder;
            _character = character;
            _enemySpawner = enemySpawner;
        }

        public void Start()
        {
            _currentTimeToWin = _levelConfig.TimeToWin;
            _isRunning = true;

            _enemySpawner.SpawnEntity(_levelConfig.EnemiesCooldown);
        }

        public void Update(float deltatime)
        {
            if(_isRunning == false)
                return;

            ProcessCountingVictoryTime(deltatime);

            if (VictoryConditionCompleted())
            {
                ProcessVictory();
                return;
            }

            if(DefeatConditionCompleted())
                ProcessDefeat();

        }

        private void ProcessCountingVictoryTime(float deltaTime) => _currentTimeToWin -= deltaTime;

        private bool VictoryConditionCompleted()
        {
            switch (_levelConfig.VictoryConditions)
            {
                case VictoryConditions.NotDieForACertainTime:
                    return _currentTimeToWin <= 0;
                case VictoryConditions.KillCertainEnemiesNumber:
                    return _enemyHolder.KilledEnemy >= _levelConfig.EnemyToKill;
                default:
                    throw new InvalidOperationException("An unprocessed victory condition");
            }
        }

        private void ProcessVictory()
        {
            ProcessEndGame();
            Victory?.Invoke();
        }

        private bool DefeatConditionCompleted()
        {
            switch (_levelConfig.DefeatConditions)
            {
                case DefeatConditions.CharacterIsDead:
                    return _character.IsDead;
                case DefeatConditions.EnemiesNumberIsMoreThanCertainQuanity:
                    return _enemyHolder.EnemyCount >= _levelConfig.EnemyNumbersToDefeat;
                default:
                    throw new InvalidOperationException("An unprocessed defeat condition");
            }
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
