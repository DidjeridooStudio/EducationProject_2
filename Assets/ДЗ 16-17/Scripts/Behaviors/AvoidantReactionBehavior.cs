
using UnityEngine;

namespace HW16_17
{
    public class AvoidantReactionBehavior : ImplementsMovementBehavior, IReactionBehavior
    {
        private Transform _characterTransform;
        public AvoidantReactionBehavior(Transform objectTransform, Transform characterTransform)
        {
            _objectTransform = objectTransform;
            _characterTransform = characterTransform;
        }

        #region Interface

        public void React()
        {
            Vector3 direction = DirectionToTarget(_characterTransform.position);

            Vector3 normalizedDirection = direction.normalized;
            normalizedDirection.y = 0;

            ProcessMoveTo(-normalizedDirection);
        }

        #endregion
    }
}
