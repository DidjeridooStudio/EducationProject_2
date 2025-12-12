using System.Diagnostics;
using UnityEngine;

namespace HW26
{
    public class Character : MonoBehaviour, IGroundCheckable
    {
        private const string HorizontalAxisName = "Horizontal";

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private ObstacleChecker _groundChecker;
        [SerializeField] private ObstacleChecker _ceilChecker;
        [SerializeField] private ObstacleChecker _wallsChecker;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _gravity;
        [SerializeField] private float _yVelocityForJump;

        private readonly Vector2 GroundCheckDirection = new Vector2(0, -1);
        private readonly Vector2 CeilCheckDirection = new Vector2(0, 1);

        private Vector2 _velocity;
        private bool _jumpPressed;

        public Vector2 Velocity => _rigidbody.velocity;
        public bool IsDead { get; set; }

        private Quaternion TurnRight => Quaternion.identity;
        private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

        private void Update()
        {
            _jumpPressed = Input.GetKeyDown(KeyCode.Space);

            float xInput = Input.GetAxisRaw(HorizontalAxisName);

            float horizontalVelocity = _moveSpeed * xInput;

            _velocity = new Vector2(horizontalVelocity, _velocity.y);

            HandleGravity();

            HandleJump();

            HandleCeil();

            _rigidbody.velocity = _velocity;

            transform.rotation = GetRotationFrom(_velocity);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent<IDamageDealing>(out IDamageDealing damageDealing))
                IsDead = true;
        }

        public bool IsGrounded() => _groundChecker.IsTouched(GroundCheckDirection);

        private void HandleGravity()
        {
            if (_groundChecker.IsTouched(GroundCheckDirection) && _velocity.y <= 0)
                _velocity.y = 0;
            else
                _velocity.y -= _gravity * Time.deltaTime;
        }

        private void HandleJump()
        {
            if ((_wallsChecker.IsTouched(transform.right) || _groundChecker.IsTouched(GroundCheckDirection)) && _jumpPressed)
                _velocity.y = _yVelocityForJump;
        }

        private void HandleCeil()
        {
            if (_ceilChecker.IsTouched(CeilCheckDirection))
                _velocity.y = Mathf.Min(0, _velocity.y);
        }

        private Quaternion GetRotationFrom(Vector2 velocity)
        {
            if (velocity.x > 0)
                return TurnRight;

            if (velocity.x < 0)
                return TurnLeft;

            return transform.rotation;
        }
    }
}
