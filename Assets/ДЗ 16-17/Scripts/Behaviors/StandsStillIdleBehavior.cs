
using System.Collections.Generic;
using UnityEngine;

namespace HW16_17
{
    public class StandsStillIdleBehavior : ImplementsMovementBehavior, IIdleBehavior
    {
        private Vector3 _currentTarget;

        public StandsStillIdleBehavior(Transform objectTransform) : base(objectTransform)
        {
            _currentTarget = objectTransform.position;
        }

        #region Interface

        public void BeIdle()
        {
            Vector3 direction = DirectionToTarget(_currentTarget);

            if (IsTargetReached(direction) == false)
                ProcessMoveTo(direction.normalized);
        }

        #endregion
    }
}
