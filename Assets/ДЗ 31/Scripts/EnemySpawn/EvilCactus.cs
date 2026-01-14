using System;
using UnityEngine;

namespace HW_31
{
    public class EvilCactus : MonoDestroyable, IShootDamagable
    {
        public event Action<EvilCactus> Killed;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent<IHitDamagable>(out IHitDamagable damagable))
                damagable.TakeDamage();
        }

        #region interface

        public void TakeDamage()
        {
            Killed?.Invoke(this);
            Destroy(gameObject);
        }

        #endregion
    }
}
