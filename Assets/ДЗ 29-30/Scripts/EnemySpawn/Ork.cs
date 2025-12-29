
using UnityEngine;

namespace HW29_30
{
    public class Ork : Enemy
    {
        [SerializeField] private float _attackSpeed;
        [SerializeField] private int _stamina;
        [SerializeField] private int _strength;

        public void Initialize(int health, int damage, float attackSpeed, int stamina, int strength)
        {
            _health = health;
            _damage = damage;
            _attackSpeed = attackSpeed;
            _stamina = stamina;
            _strength = strength;
        }
    }
}
