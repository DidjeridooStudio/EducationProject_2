using System;
using UnityEngine;

namespace HW_31
{
    public class GameplayCircle : IDisposable
    {
        private CharacterFactory _characterFactory;
        private LevelConfig _levelConfig;
        private Character _character;
        private GameMode _gameMode;
        private EnemyHolder _enemyHolder;
        private EvilCactusSpawner _evilCactusSpawner;
        private GameView _gameView;

        public GameplayCircle(
            CharacterFactory characterFactory,
            LevelConfig levelConfig,
            EnemyHolder enemyHolder,
            EvilCactusSpawner evilCactusSpawner,
            GameView gameView)
        {
            _characterFactory = characterFactory;
            _levelConfig = levelConfig;
            _enemyHolder = enemyHolder;
            _evilCactusSpawner = evilCactusSpawner;
            _gameView = gameView;
        }

        public void Prepare()
        {
            _character = _characterFactory.CreateCharacter(_levelConfig.CharacterConfig, _levelConfig.CharacterSpawnPoint);
        }

        public void Launch()
        {
            _gameMode = new GameMode(_levelConfig, _enemyHolder, _character, _evilCactusSpawner);

            _gameMode.Victory += OnGameModeVictory;
            _gameMode.Defeat += OnGameModeDefeat;

            _gameMode.Start();

            _gameView.Initialize(_enemyHolder, _gameMode);
        }

        public void Update(float deltaTime)
        {
            _gameMode?.Update(deltaTime);
        }

        private void OnGameModeEnded()
        {
            if( _gameMode != null )
            {
                _gameMode.Victory -= OnGameModeVictory;
                _gameMode.Defeat -= OnGameModeDefeat;
            }
        }

        private void OnGameModeVictory()
        {
            OnGameModeEnded();
        }

        private void OnGameModeDefeat()
        {
            OnGameModeEnded();
        }

        #region Interface

        public void Dispose()
        {
            OnGameModeEnded();
        }

        #endregion
    }
}
