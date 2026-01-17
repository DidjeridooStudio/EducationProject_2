using System;
using TMPro;
using UnityEngine;

namespace HW_31
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tMP_Text_LevelTime;
        [SerializeField] private TMP_Text _tMP_Text_KilledEnemy;
        [SerializeField] private TMP_Text _tMP_Text_EnemyOnLevel;
        [SerializeField] private TMP_Text _tMP_Text_GameResult;

        private EnemyHolder _enemyHolder;
        private GameMode _gameMode;
        private float _currentTimeToWin;
        private bool _isRunning;

        public void Initialize(EnemyHolder enemyHolder, GameMode gameMode)
        {
            _enemyHolder = enemyHolder;
            _gameMode = gameMode;
            _gameMode.Victory += OnGameModeVictory;
            _gameMode.Defeat += OnGameModeDefeat;

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            _currentTimeToWin += Time.deltaTime;

            _tMP_Text_LevelTime.text = "Level time: " + Math.Round(_currentTimeToWin, 1);
            _tMP_Text_KilledEnemy.text = "Killed enemy: " + _enemyHolder.KilledEnemy;
            _tMP_Text_EnemyOnLevel.text = "Enemy on level: " + _enemyHolder.EnemyCount;
        }

        private void OnGameModeVictory()
        {
            ShowGameResultMessage("You win");
        }

        private void OnGameModeDefeat()
        {
            ShowGameResultMessage("You loose");
        }

        private void ShowGameResultMessage(string text)
        {
            _tMP_Text_GameResult.gameObject.SetActive(true);
            _tMP_Text_GameResult.text = text;
            _isRunning = false;
        }

        private void OnDestroy()
        {
            if (_gameMode != null)
            {
                _gameMode.Victory -= OnGameModeVictory;
                _gameMode.Defeat -= OnGameModeDefeat;
            }
        }
    }
}
