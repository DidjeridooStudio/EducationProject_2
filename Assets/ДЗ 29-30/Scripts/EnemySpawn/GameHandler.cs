using HW29_30.HW29_30;
using System.Collections.Generic;
using UnityEngine;
using static HW29_30.EnemiesSettings;

namespace HW29_30
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private EnemiesSettings _enemiesSettings;

        private void Awake()
        {
            List<EnemyConfig> _enemyConfigs = new List<EnemyConfig>();

            _enemyConfigs.AddRange(_enemiesSettings.OrkConfigs);
            _enemySpawner.SpawnEnemy(_enemyConfigs);
            _enemyConfigs.Clear();

            _enemyConfigs.AddRange(_enemiesSettings.ElfConfigs);
            _enemySpawner.SpawnEnemy(_enemyConfigs);
            _enemyConfigs.Clear();

            _enemyConfigs.AddRange(_enemiesSettings.DragonConfigs);
            _enemySpawner.SpawnEnemy(_enemyConfigs);
            _enemyConfigs.Clear();
        }
    }
}
