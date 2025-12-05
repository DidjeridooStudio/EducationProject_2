using UnityEngine;

namespace HW24_25
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

        public void GetHealing(int value)
        {
            if (value < 0)
                return;

            _value += value;
        }
    }
}
