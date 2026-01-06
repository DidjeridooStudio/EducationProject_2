using System.Collections.Generic;
using UnityEngine;
using static HW29_30.EnemiesSettings;

namespace HW29_30
{
    public class EnemySpawner : MonoBehaviour
    {
        private const int EnemyQuanity = 3;

        public void SpawnEnemy(List<EnemyConfig> enemyConfigs)
        {
            for (int i = 0; i < EnemyQuanity; i++)
            {
                int RandomIndex = Random.Range(0, enemyConfigs.Count);
                EnemyConfig enemyConfig = enemyConfigs[RandomIndex];
                InstantiateEnemy(enemyConfig);
            }
        }

        private void InstantiateEnemy(EnemyConfig enemyConfig)
        {
            switch(enemyConfig)
            {
                case OrkConfig:
                    Ork ork = (Ork)Instantiate(enemyConfig.Prefab, transform.position, Quaternion.identity);
                    ork.Initialize((OrkConfig)enemyConfig);
                    break;
                case ElfConfig:
                    Elf elf = (Elf)Instantiate(enemyConfig.Prefab, transform.position, Quaternion.identity);
                    elf.Initialize((ElfConfig)enemyConfig);
                    break;
                case DragonConfig:
                    Dragon dragon = (Dragon)Instantiate(enemyConfig.Prefab, transform.position, Quaternion.identity);
                    dragon.Initialize((DragonConfig)enemyConfig);
                    break;
                default:
                    break;
            }
        }
    }
}
