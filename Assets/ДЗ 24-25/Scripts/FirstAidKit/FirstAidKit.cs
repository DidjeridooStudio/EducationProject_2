using UnityEngine;

namespace HW24_25
{
    public class FirstAidKit : MonoBehaviour
    {
        [SerializeField] private int _addedHealth;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.GetHealing(_addedHealth);
                Destroy(gameObject);
            }
        }
    }
}
