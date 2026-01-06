using System;
using System.Collections.Generic;
using UnityEngine;

namespace HW29_30
{
    [Serializable]
    public class EnemiesSettings
    {
        [SerializeField] private List<OrkConfig> _orkConfigs;
        [SerializeField] private List<ElfConfig> _elfConfigs;
        [SerializeField] private List<DragonConfig> _dragonConfigs;

        private List<EnemyConfig> _enemyConfigs;

        public List<OrkConfig> OrkConfigs => _orkConfigs;
        public List<ElfConfig> ElfConfigs => _elfConfigs;
        public List<DragonConfig> DragonConfigs => _dragonConfigs;

        public List<EnemyConfig> EnemyConfigs1(List<EnemyConfig> enemyConfigs)
        {
            _enemyConfigs = new List<EnemyConfig>();

            _enemyConfigs.AddRange(enemyConfigs);

            return _enemyConfigs;
        }

        public class EnemyConfig
        {
            [field: SerializeField] public Enemy Prefab { get; private set; }
            [field: SerializeField] public int Health { get; private set; }
            [field: SerializeField] public int Damage { get; private set; }
        }

        [Serializable]
        public class OrkConfig : EnemyConfig
        {
            [field: SerializeField] public float AttackSpeed { get; private set; }
            [field: SerializeField] public int Stamina { get; private set; }
            [field: SerializeField] public int Strength { get; private set; }
        }

        [Serializable]
        public class ElfConfig : EnemyConfig
        {
            [field: SerializeField] public float AttackRange { get; private set; }
            [field: SerializeField] public int Agility { get; private set; }
            [field: SerializeField] public int Charisma { get; private set; }
        }

        [Serializable]
        public class DragonConfig : EnemyConfig
        {
            [field: SerializeField] public float FireballSpeed { get; private set; }
            [field: SerializeField] public int Mana { get; private set; }
            [field: SerializeField] public int Age { get; private set; }
        }
    }
}
