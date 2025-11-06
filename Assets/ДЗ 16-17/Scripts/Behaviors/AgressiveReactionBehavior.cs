using Unity.VisualScripting;
using UnityEngine;

namespace HW16_17
{
    public class AgressiveReactionBehavior : ImplementsMovementBehavior, IReactionBehavior
    {
        private Transform _characterTransform;

        public AgressiveReactionBehavior(Transform objectTransform, Transform characterTransform) : base(objectTransform)
        {
            _characterTransform = characterTransform;
        }

        #region Interface

        public void React()
        {
            Vector3 direction = DirectionToTarget(_characterTransform.position);

            if (IsTargetReached(direction) == false)
            {
                Vector3 normalizedDirection = direction.normalized;
                normalizedDirection.y = 0;

                ProcessMoveTo(normalizedDirection);
            }
        }

        #endregion
    }
}
