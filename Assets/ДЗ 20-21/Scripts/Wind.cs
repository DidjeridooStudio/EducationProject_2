using UnityEngine;

namespace HW20_21
{
    public class Wind : MonoBehaviour
    {
        [SerializeField] private Vector3 _direction;
        [SerializeField] private Transform _windIndicatorTransform;
        [SerializeField] private float _force;

        private const float _speedIndicatorRotation = 100f;

        public Vector3 Direction => _direction;
        public float Force => _force;

        private void Update()
        {
            Quaternion lookRotation = Quaternion.LookRotation(_direction.normalized);
            _windIndicatorTransform.rotation = Quaternion.RotateTowards(_windIndicatorTransform.rotation, lookRotation, _speedIndicatorRotation * Time.deltaTime);
        }
    }
}
