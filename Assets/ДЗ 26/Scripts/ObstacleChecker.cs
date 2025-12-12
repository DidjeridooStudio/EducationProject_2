using UnityEngine;

namespace HW26
{
    public class ObstacleChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private CapsuleCollider2D _collider;
        [SerializeField] private float _distanceToCheck;

        public bool IsTouched(Vector2 checkDirrection)
        {
            RaycastHit2D raycastHit = Physics2D.CapsuleCast(_collider.bounds.center, _collider.size, _collider.direction, 0, checkDirrection, _distanceToCheck, _layerMask);
            return raycastHit.collider != null;
        }
    }
}
