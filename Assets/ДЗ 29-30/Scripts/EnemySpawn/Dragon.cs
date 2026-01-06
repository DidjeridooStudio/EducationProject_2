
using UnityEngine;
using static HW29_30.EnemiesSettings;

namespace HW29_30
{
    public class Dragon : Enemy
    {
        [SerializeField] private float _fireballSpeed;
        [SerializeField] private int _mana;
        [SerializeField] private int _age;

        public void Initialize(DragonConfig config)
        {
            Health = config.Health;
            Damage = config.Damage;
            _fireballSpeed = config.FireballSpeed;
            _mana = config.Mana;
            _age = config.Age;
        }
    }
}
