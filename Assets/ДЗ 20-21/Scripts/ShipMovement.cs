using TMPro;
using UnityEngine;

namespace HW20_21
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] private Wind _wind;
        [SerializeField] private Transform _sailsTransform;
        [SerializeField] private float _forceSpeed;
        [SerializeField] private TMP_Text _forceText;

        private Rigidbody _rigidbody;

        private bool _isMoving;
        private float _windDotProduct;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _windDotProduct = Vector3.Dot(_wind.Direction.normalized, _sailsTransform.forward.normalized);
            float shipDotProduct = Vector3.Dot(transform.forward.normalized, _sailsTransform.forward.normalized);

            _isMoving = _windDotProduct > 0.01f && shipDotProduct > 0.01f;

            _forceText.text = _isMoving ? "Speed:" + _windDotProduct * _wind.Force : "Speed: 0";
        }

        private void FixedUpdate()
        {
            if (_isMoving)
                _rigidbody.AddRelativeForce(Vector3.forward * _windDotProduct * _wind.Force);
        }
    }
}
