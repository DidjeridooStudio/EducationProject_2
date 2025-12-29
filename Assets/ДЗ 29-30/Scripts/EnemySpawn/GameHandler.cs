using UnityEngine;

namespace HW29_30
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private EnemiesSettings _enemiesSettings;

        private void Awake()
        {
            _enemySpawner.SpawnOrks(_enemiesSettings.OrkConfigs);
            _enemySpawner.SpawnElfs(_enemiesSettings.ElfConfigs);
            _enemySpawner.SpawnDragons(_enemiesSettings.DragonConfigs);
        }
    }
}
