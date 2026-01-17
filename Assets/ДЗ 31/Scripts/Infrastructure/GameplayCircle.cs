using System;

namespace HW_31
{
    public class GameplayCircle : IDisposable
    {
        private CharacterFactory _characterFactory;
        private LevelConfig _levelConfig;
        private CharacterConfig _characterConfig;
        private Character _character;
        private GameMode _gameMode;
        private GameModeFactory _gameModeFactory;

        public GameplayCircle(
            CharacterFactory characterFactory,
            LevelConfig levelConfig,
            CharacterConfig characterConfig,
            GameModeFactory gameModeFactory)
        {
            _characterFactory = characterFactory;
            _levelConfig = levelConfig;
            _characterConfig = characterConfig;
            _gameModeFactory = gameModeFactory;
        }

        public void Prepare()
        {
            _character = _characterFactory.CreateCharacter(_characterConfig, _levelConfig.CharacterSpawnPoint);
        }

        public void Launch()
        {
            _gameMode = _gameModeFactory.CreateGameMode(_character);

            _gameMode.Victory += OnGameModeVictory;
            _gameMode.Defeat += OnGameModeDefeat;

            _gameMode.Start();
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
