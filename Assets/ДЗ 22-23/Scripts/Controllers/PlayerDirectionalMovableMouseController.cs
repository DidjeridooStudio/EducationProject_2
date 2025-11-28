using UnityEngine;
using UnityEngine.AI;

namespace HW22_23
{
    public class PlayerDirectionalMovableMouseController : Controller
    {
        private const int StartCornerIndex = 0;
        private const int TargetCornerIndex = 1;
        private const int LeftMouseButton = 0;
        private const float MinDistanceToTarget = 0.05f;

        private IDirectionalMovable _movable;
        private NavMeshQueryFilter _queryFilter;
        private NavMeshPath _pathToTarget;
        private Camera _mainCamera;
        private LayerMask _groundLayerMask;

        private Vector3 _targetPosition;

        public bool HasValidTargetPosition => _targetPosition != Vector3.zero;

        public Vector3 TargetPosition => _targetPosition;

        public PlayerDirectionalMovableMouseController(IDirectionalMovable movable, NavMeshQueryFilter queryFilter, LayerMask groundLayerMask)
        {
            _movable = movable;
            _queryFilter = queryFilter;
            _groundLayerMask = groundLayerMask;

            _mainCamera = Camera.main;
            _pathToTarget = new NavMeshPath();
            _targetPosition = Vector3.zero;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            if (Input.GetMouseButtonDown(LeftMouseButton))
                SetTargerPosition();

            if (HasValidTargetPosition)
                TryGetTargetPosition();
            else
                _movable.SetMoveDirection(Vector3.zero);

        }

        private void SetTargerPosition()
        {
            Ray Ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Ray, out RaycastHit hitinfo, _groundLayerMask))
                _targetPosition = hitinfo.point;
            else
                _targetPosition = Vector3.zero;
        }

        private void TryGetTargetPosition()
        {
            if (NavMeshUtils.TryGetPath(_movable.Position, _targetPosition, _queryFilter, _pathToTarget))
            {
                float distanceToTarget = NavMeshUtils.GetPathLength(_pathToTarget);

                if (IsTargetReached(distanceToTarget))
                {
                    _targetPosition = Vector3.zero;
                    return;
                }

                Vector3 direction = _pathToTarget.corners[TargetCornerIndex] - _pathToTarget.corners[StartCornerIndex];
                _movable.SetMoveDirection(direction);

                return;
            }
            else
            {
                _targetPosition = Vector3.zero;
            }

            _movable.SetMoveDirection(Vector3.zero);
        }

        private bool IsTargetReached(float distanceToTarget) => distanceToTarget <= MinDistanceToTarget;
    }
}
