using UnityEngine;

namespace HW_31
{
    public class Arrow : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IShootDamagable>(out IShootDamagable damagable))
            {
                damagable.TakeDamage();
                Destroy(gameObject);
            }
        }
    }
}
