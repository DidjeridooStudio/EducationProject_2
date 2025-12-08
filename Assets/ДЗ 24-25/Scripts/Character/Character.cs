using HW22_23;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace HW24_25
{
    public class Character : MonoBehaviour, IDirectionalMovable, IDirectionalRotatable, IDamagable, IHealable, IJumpable, ISetTargetPosition
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private int _maxHealthValue;
        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField] private TMP_Text _tMP_Text;

        private DirectionalMover _mover;
        private DirectionalRotator _rotator;
        private Health _health;
        private NavMeshAgent _agent;
        private NavMeshAgentJumper _jumper;

        private Vector3 _targetPosition;

        #region interface

        public Vector3 CurrentVelocity => _mover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;
        public Vector3 Position => transform.position;
        public int HealthValue => _health.Value;
        public int HealthPercent => HealthValue * 100 / _maxHealthValue;
        public bool InJumpProcess => _jumper.InProcess;

        #endregion

        private void Awake()
        {
            _mover = new DirectionalMover(GetComponent<CharacterController>(), _movementSpeed);
            _rotator = new DirectionalRotator(transform, _rotationSpeed);
            _health = new Health(_maxHealthValue);

            _agent = GetComponent<NavMeshAgent>();
            _jumper = new NavMeshAgentJumper(_jumpSpeed, _agent, this, _jumpCurve);

            _agent.updatePosition = false;
            _agent.updateRotation = false;

            _tMP_Text.text = $"Health: {_health.Value}";
        }

        private void Update()
        {
            _mover.Update(Time.deltaTime);
            _rotator.Update(Time.deltaTime);

            _agent.nextPosition = transform.position;
        }

        #region interface

        public void SetMoveDirection(Vector3 direction) => _mover.SetInputDirection(direction);
        public void SetRotateDirection(Vector3 direction) => _rotator.SetInputDirection(direction);
        public void SetTargetPosition(Vector3 position) => _targetPosition = position;

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
            SetMoveDirection(Vector3.zero);
            _tMP_Text.text = $"Health: {_health.Value}";
        }

        public void GetHealing(int value)
        {
            _health.GetHealing(value);
            _tMP_Text.text = $"Health: {_health.Value}";
        }

        public bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData)
        {
            _agent.SetDestination(_targetPosition);

            if (_agent.isOnOffMeshLink)
            {
                offMeshLinkData = _agent.currentOffMeshLinkData;
                return true;
            }

            offMeshLinkData = default(OffMeshLinkData);
            return false;
        }

        public void Jump(OffMeshLinkData offMeshLinkData) => _jumper.Jump(offMeshLinkData);

        #endregion
    }
}
