using UnityEngine;

namespace BeaSwarm
{
    public class Character : MonoBehaviour, IDirectionalMovable, IDirectionalRotatable
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        private DirectionalMover _mover;
        private DirectionalRotator _rotator;

        #region interface

        public Vector3 CurrentVelocity => _mover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;
        public Vector3 Position => transform.position;

        #endregion

        private void Awake()
        {
            _mover = new DirectionalMover(GetComponent<CharacterController>(), _movementSpeed);
            _rotator = new DirectionalRotator(transform, _rotationSpeed);
        }

        private void Update()
        {
            _mover.Update(Time.deltaTime);
            _rotator.Update(Time.deltaTime);
        }

        #region interface

        public void SetMoveDirection(Vector3 direction) => _mover.SetInputDirection(direction);
        public void SetRotateDirection(Vector3 direction) => _rotator.SetInputDirection(direction);

        #endregion
    }
}
