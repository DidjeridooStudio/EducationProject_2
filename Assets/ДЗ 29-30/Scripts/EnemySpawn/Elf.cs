
using UnityEngine;

namespace HW29_30
{
    public class Elf : Enemy
    {
        [SerializeField] private float _attackRange;
        [SerializeField] private int _agility;
        [SerializeField] private int _charisma;

        public void Initialize(int health, int damage, float attackRange, int agility, int charisma)
        {
            _health = health;
            _damage = damage;
            _attackRange = attackRange;
            _agility = agility;
            _charisma = charisma;
        }
    }
}
