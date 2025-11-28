using UnityEngine;

namespace HW22_23
{
    public class Health
    {
        private int _value;

        public Health(int value)
        {
            _value = value;
        }

        public int Value => _value;

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                return;

            _value -= damage;
        }
    }
}
