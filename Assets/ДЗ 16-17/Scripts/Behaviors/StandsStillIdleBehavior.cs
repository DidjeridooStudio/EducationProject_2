
using System.Collections.Generic;
using UnityEngine;

namespace HW16_17
{
    public class StandsStillIdleBehavior : ImplementsMovementBehavior, IIdleBehavior
    {
        public StandsStillIdleBehavior(Transform objectTransform)
        {
            _objectTransform = objectTransform;
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
