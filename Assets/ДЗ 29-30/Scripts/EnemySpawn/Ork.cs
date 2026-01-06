using UnityEngine;
using static HW29_30.EnemiesSettings;

namespace HW29_30
{
    public class Ork : Enemy
    {
        [SerializeField] private float _attackSpeed;
        [SerializeField] private int _stamina;
        [SerializeField] private int _strength;

        public void Initialize(OrkConfig config)
        {
            Health = config.Health;
            Damage = config.Damage;
            _attackSpeed = config.AttackSpeed;
            _stamina = config.Stamina;
            _strength = config.Strength;
        }
    }
}
