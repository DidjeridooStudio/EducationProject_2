using UnityEngine;

namespace HW16_17
{
    public abstract class ImplementsMovementBehavior
    {
        private const float MoveSpeed = 5f;
        private const float MinDistanceToTarget = 0.05f;

        private Transform _objectTransform;

        protected ImplementsMovementBehavior(Transform objectTransform)
        {
            _objectTransform = objectTransform;
        }

        protected Vector3 DirectionToTarget(Vector3 targetPosition) => DistanceDetector.DirectionToTarget(targetPosition, _objectTransform.position);

        protected bool IsTargetReached(Vector3 directionToTarget) => DistanceDetector.IsTargetInSpecifiedZone(directionToTarget, MinDistanceToTarget);

        protected void ProcessMoveTo(Vector3 direction) => _objectTransform.Translate(direction * MoveSpeed * Time.deltaTime, Space.World);
    }
}
