using HW16_17;
using System.Collections.Generic;
using UnityEngine;

namespace HW26
{
    public class PatrolEntity : MonoBehaviour, IDamageDealing
    {
        private const float MoveSpeed = 3f;
        private const float MinDistanceToTarget = 0.05f;

        [SerializeField] private List<Transform> _targetsTransform;

        private Vector3 _currentTarget;
        private Queue<Vector3> _targetsPosition;

        private Quaternion TurnRight => Quaternion.identity;
        private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

        private void Awake()
        {
            _targetsPosition = new Queue<Vector3>();

            foreach (Transform targetTransform in _targetsTransform)
                _targetsPosition.Enqueue(targetTransform.position);

            SwitchTarget();
        }

        private void Update()
        {
            Vector2 direction = DirectionToTarget(_currentTarget);

            if (IsTargetReached(direction))
                SwitchTarget();

            ProcessMoveTo(direction.normalized);

            transform.rotation = GetRotationFrom(direction);
        }

        private void SwitchTarget()
        {
            _currentTarget = _targetsPosition.Dequeue();
            _targetsPosition.Enqueue(_currentTarget);
        }

        private Vector3 DirectionToTarget(Vector3 targetPosition) => DistanceDetector.DirectionToTarget(targetPosition, transform.position);

        private bool IsTargetReached(Vector3 directionToTarget) => DistanceDetector.IsTargetInSpecifiedZone(directionToTarget, MinDistanceToTarget);

        private void ProcessMoveTo(Vector3 direction) => transform.Translate(direction * MoveSpeed * Time.deltaTime, Space.World);

        private Quaternion GetRotationFrom(Vector2 direction)
        {
            if (direction.x > 0)
                return TurnLeft;

            if (direction.x < 0)
                return TurnRight;

            return transform.rotation;
        }
    }
}
