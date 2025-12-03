using HW22_23;
using UnityEngine;
using UnityEngine.AI;

namespace HW24_25
{
    public class Character : MonoBehaviour, IDirectionalMovable, IDirectionalRotatable, IDamagable, IJumpable
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private int _maxHealthValue;

        private DirectionalMover _mover;
        private DirectionalRotator _rotator;
        private Health _health;
        private NavMeshAgent _agent;
        private NavMeshAgentJumper _jumper;

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
            _jumper = new NavMeshAgentJumper(_jumpSpeed, _agent, this);

            _agent.updatePosition = false;
            _agent.updateRotation = false;
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

        public bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData)
        {
            _agent.SetDestination(transform.position);

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
