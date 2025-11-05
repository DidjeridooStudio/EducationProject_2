using UnityEngine;

namespace HW16_17
{
    public abstract class ImplementsMovementBehavior
    {
        protected const float MoveSpeed = 5f;
        protected const float MinDistanceToTarget = 0.05f;

        protected Vector3 _currentTarget;
        protected Transform _objectTransform;

        protected Vector3 DirectionToTarget(Vector3 targetPosition) => DistanceDetector.DirectionToTarget(targetPosition, _objectTransform.position);

        protected bool IsTargetReached(Vector3 directionToTarget) => DistanceDetector.IsTargetInSpecifiedZone(directionToTarget, MinDistanceToTarget);

        protected void ProcessMoveTo(Vector3 direction) => _objectTransform.Translate(direction * MoveSpeed * Time.deltaTime, Space.World);
    }
}
