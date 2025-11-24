using UnityEngine;

namespace HW20_21
{
    [RequireComponent(typeof(Rigidbody))]
    public class StandardPushedObject : MonoBehaviour, IPhysicallyPushed, IDraggable
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        #region Interface
        public Vector3 Position => transform.position;

        public void GetPush(Vector3 force)
        {
            _rigidbody.AddForce(force, ForceMode.Impulse);
            _rigidbody.AddTorque(force);
        }

        public void OnGrab()
        {
            _rigidbody.isKinematic = true;
        }

        public void Drag(Vector3 position)
        {
            transform.position = position;
        }

        public void OnRelease()
        {
            _rigidbody.isKinematic = false;
        }

        #endregion
    }
}
