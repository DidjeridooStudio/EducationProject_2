using HW22_23;
using UnityEngine;

namespace HW_31
{
    public class Character : MonoBehaviour, IDirectionalMovable, IDirectionalRotatable, IHitDamagable
    {
        [SerializeField] private Bow _bow;
        [SerializeField] private Transform _cameraTarget;

        private const KeyCode ShootKey = KeyCode.F;

        private DirectionalMover _mover;
        private DirectionalRotator _rotator;

        public bool IsDead { get; private set; }
        public Transform CameraTarget => _cameraTarget;

        #region interface

        public Vector3 CurrentVelocity => _mover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;
        public Vector3 Position => transform.position;

        #endregion

        public void Initialize(DirectionalMover mover, DirectionalRotator rotator)
        {
            _mover = mover;
            _rotator = rotator;

            foreach (IInitializable initializable in GetComponentsInChildren<IInitializable>())
                initializable.Initialize();
        }

        private void Update()
        {
            _mover.Update(Time.deltaTime);
            _rotator.Update(Time.deltaTime);

            if (Input.GetKeyDown(ShootKey))
            {
                _bow.Use();
            }
        }

        #region interface

        public void SetMoveDirection(Vector3 direction) => _mover.SetInputDirection(direction);
        public void SetRotateDirection(Vector3 direction) => _rotator.SetInputDirection(direction);

        public void TakeDamage()
        {
            IsDead = true;
        }

        #endregion
    }
}
