using UnityEngine;

namespace HW20_21
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private KeyCode _leftRotationKey;
        [SerializeField] private KeyCode _rightRotationKey;
        [SerializeField] private float _maxAngelRotation;
        [SerializeField] private bool _hasLimitAngelRotation;

        private Quaternion _maxEngelRight;
        private Quaternion _maxEngelLeft;

        private void Awake()
        {
            _maxEngelRight = Quaternion.Euler(new Vector3(0, _maxAngelRotation, 0));
            _maxEngelLeft = Quaternion.Euler(new Vector3(0, -_maxAngelRotation, 0));
        }

        private void Update()
        {
            ProcessRotateTo();
        }

        public void ProcessRotateTo()
        {
            if (Input.GetKey(_leftRotationKey))
            {
                if (_hasLimitAngelRotation && transform.localRotation == _maxEngelLeft)
                    return;

                transform.Rotate(Vector3.up * -_rotateSpeed * Time.deltaTime); 
            }
            else if (Input.GetKey(_rightRotationKey))
            {
                if (_hasLimitAngelRotation && transform.localRotation == _maxEngelRight)
                    return;

                transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
            }
        }
    }
}
