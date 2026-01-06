
using UnityEngine;
using static HW29_30.EnemiesSettings;

namespace HW29_30
{
    public class Elf : Enemy
    {
        [SerializeField] private float _attackRange;
        [SerializeField] private int _agility;
        [SerializeField] private int _charisma;

        public void Initialize(ElfConfig config)
        {
            Health = config.Health;
            Damage = config.Damage;
            _attackRange = config.AttackRange;
            _agility = config.Agility;
            _charisma = config.Charisma;
        }
    }
}
