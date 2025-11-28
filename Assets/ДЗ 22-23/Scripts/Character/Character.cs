using UnityEngine;

namespace HW22_23
{
    public class Character : MonoBehaviour, IDirectionalMovable, IDirectionalRotatable, IDamagable
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private int _maxHealthValue;

        private DirectionalMover _mover;
        private DirectionalRotator _rotator;
        private Health _health;

        #region interface

        public Vector3 CurrentVelocity => _mover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;
        public Vector3 Position => transform.position;
        public int HealthValue => _health.Value;
        public int HealthPercent => HealthValue * 100 / _maxHealthValue;

        #endregion

        private void Awake()
        {
            _mover = new DirectionalMover(GetComponent<CharacterController>(), _movementSpeed);
            _rotator = new DirectionalRotator(transform, _rotationSpeed);
            _health = new Health(_maxHealthValue);
        }

        private void Update()
        {
            _mover.Update(Time.deltaTime);
            _rotator.Update(Time.deltaTime);
        }

        #region interface

        public void SetMoveDirection(Vector3 direction) => _mover.SetInputDirection(direction);
        public void SetRotateDirection(Vector3 direction) => _rotator.SetInputDirection(direction);

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            SetMoveDirection(Vector3.zero);
        }

        #endregion
    }
}
