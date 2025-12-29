using System.Collections.Generic;
using UnityEngine;
using static HW29_30.EnemiesSettings;

namespace HW29_30
{
    public class EnemySpawner : MonoBehaviour
    {
        private const int _enemyQuanity = 3;

        public void SpawnOrks(List<OrkConfig> enemyConfigs)
        {
            for (int i = 0; i < _enemyQuanity; i++)
            {
                int RandomIndex = Random.Range(0, enemyConfigs.Count);
                OrkConfig enemyConfig = enemyConfigs[RandomIndex];
                Ork ork = Instantiate(enemyConfig.Prefab, transform.position, Quaternion.identity);
                ork.Initialize(enemyConfig.Health, enemyConfig.Damage, enemyConfig.AttackSpeed, enemyConfig.Stamina, enemyConfig.Strength);
            }
        }

        public void SpawnElfs(List<ElfConfig> enemyConfigs)
        {
            for (int i = 0; i < _enemyQuanity; i++)
            {
                int RandomIndex = Random.Range(0, enemyConfigs.Count);
                ElfConfig enemyConfig = enemyConfigs[RandomIndex];
                Elf elf = Instantiate(enemyConfig.Prefab, transform.position, Quaternion.identity);
                elf.Initialize(enemyConfig.Health, enemyConfig.Damage, enemyConfig.AttackRange, enemyConfig.Agility, enemyConfig.Charisma);
            }
        }

        public void SpawnDragons(List<DragonConfig> enemyConfigs)
        {
            for (int i = 0; i < _enemyQuanity; i++)
            {
                int RandomIndex = Random.Range(0, enemyConfigs.Count);
                DragonConfig enemyConfig = enemyConfigs[RandomIndex];
                Dragon dragon = Instantiate(enemyConfig.Prefab, transform.position, Quaternion.identity);
                dragon.Initialize(enemyConfig.Health, enemyConfig.Damage, enemyConfig.FireballSpeed, enemyConfig.Mana, enemyConfig.Age);
            }
        }
    }
}
