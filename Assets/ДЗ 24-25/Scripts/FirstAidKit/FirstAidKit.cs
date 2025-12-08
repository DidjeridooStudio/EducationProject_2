using UnityEngine;

namespace HW24_25
{
    public class FirstAidKit : MonoBehaviour
    {
        [SerializeField] private int _addedHealth;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IHealable>(out IHealable healable))
            {
                healable.GetHealing(_addedHealth);
                Destroy(gameObject);
            }
        }
    }
}
