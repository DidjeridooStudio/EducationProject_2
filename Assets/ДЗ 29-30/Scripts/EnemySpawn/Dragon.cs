
using UnityEngine;

namespace HW29_30
{
    public class Dragon : Enemy
    {
        [SerializeField] private float _fireballSpeed;
        [SerializeField] private int _mana;
        [SerializeField] private int _age;

        public void Initialize(int health, int damage, float fireballSpeed, int mana, int age)
        {
            _health = health;
            _damage = damage;
            _fireballSpeed = fireballSpeed;
            _mana = mana;
            _age = age;
        }
    }
}
