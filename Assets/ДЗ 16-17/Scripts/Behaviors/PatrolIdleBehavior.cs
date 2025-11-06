using System.Collections.Generic;
using UnityEngine;

namespace HW16_17
{
    public class PatrolIdleBehavior : ImplementsMovementBehavior, IIdleBehavior
    {
        private Vector3 _currentTarget;
        private Queue<Vector3> _targetsPosition;

        public PatrolIdleBehavior(Transform objectTransform, List<Transform> targetsTransform) : base(objectTransform)
        {
            _targetsPosition = new Queue<Vector3>();

            foreach (Transform targetTransform in targetsTransform)
                _targetsPosition.Enqueue(targetTransform.position);

            SwitchTarget();
        }

        private void SwitchTarget()
        {
            _currentTarget = _targetsPosition.Dequeue();
            _targetsPosition.Enqueue(_currentTarget);
        }

        #region Interface

        public void BeIdle()
        {
            Vector3 direction = DirectionToTarget(_currentTarget);

            if (IsTargetReached(direction))
                SwitchTarget();

            ProcessMoveTo(direction.normalized);
        }

        #endregion
    }
}
