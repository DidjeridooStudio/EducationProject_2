using UnityEngine;

namespace HW_31
{
    public class Bow : MonoBehaviour
    {
        [SerializeField] private GameObject _arrowPrefab;
        [SerializeField] private float _force;
        [SerializeField] private float _arrowDestroyTime;

        public void Use()
        {
            Shoot();
        }

        private void Shoot()
        {
            GameObject arrow = InstantiateArrow();

            if (arrow.TryGetComponent<Rigidbody>(out Rigidbody arrowRigidbody))
            {
                arrowRigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
            }

            Destroy(arrow, _arrowDestroyTime);
        }

        private GameObject InstantiateArrow()
        {
            GameObject arrow = Instantiate(_arrowPrefab);
            arrow.transform.position = transform.position;

            Vector3 direction = new Vector3(arrow.transform.eulerAngles.x, transform.eulerAngles.y, arrow.transform.eulerAngles.z);
            arrow.transform.rotation = Quaternion.Euler(direction);

            return arrow;
        }
    }
}
