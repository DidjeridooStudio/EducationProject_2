using UnityEngine;

namespace HW_31
{
    public class EnemiesFactory
    {
        private EnemyHolder _enemyHolder;

        public EnemiesFactory(EnemyHolder enemyHolder)
        {
            _enemyHolder = enemyHolder;
        }

        public EvilCactus CreateEvilCactus(EvilCactusConfig config, Vector3 spawnPosition)
        {
            EvilCactus instance = Object.Instantiate(config.Prefab, spawnPosition, Quaternion.identity);

            _enemyHolder.Add(instance);

            return instance;
        }
    }
}
