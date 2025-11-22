using UnityEngine;

namespace HW20_21
{
    [RequireComponent(typeof(Rigidbody))]
    public class StandardPushedObject : MonoBehaviour, IPhysicallyPushed
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        #region Interface

        public void GetPush(Vector3 force)
        {
            _rigidbody.AddForce(force, ForceMode.Impulse);
            _rigidbody.AddTorque(force);
        }

        #endregion
    }
}
