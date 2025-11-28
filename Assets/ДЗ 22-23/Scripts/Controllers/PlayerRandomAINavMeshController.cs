using UnityEngine;
using UnityEngine.AI;

namespace HW22_23
{
    public class PlayerRandomAINavMeshController : Controller
    {
        private const int StartCornerIndex = 0;
        private const int TargetCornerIndex = 1;
        private const float MinDistanceToTarget = 0.05f;

        private IDirectionalMovable _movable;
        private NavMeshQueryFilter _queryFilter;
        private NavMeshPath _pathToTarget;

        private float _movementRadius;

        private Vector3 _targetPosition;

        public PlayerRandomAINavMeshController(IDirectionalMovable movable, NavMeshQueryFilter queryFilter, float movementRadius)
        {
            _movable = movable;
            _queryFilter = queryFilter;
            _movementRadius = movementRadius;

            _pathToTarget = new NavMeshPath();
        }

        protected override void UpdateLogic(float deltaTime)
        {
            if (NavMeshUtils.TryGetPath(_movable.Position, _targetPosition, _queryFilter, _pathToTarget))
            {
                float distanceToTarget = NavMeshUtils.GetPathLength(_pathToTarget);

                if (IsTargetReached(distanceToTarget))
                {
                    GenerateTargetPosition();
                    return;
                }

                Vector3 direction = _pathToTarget.corners[TargetCornerIndex] - _pathToTarget.corners[StartCornerIndex];
                _movable.SetMoveDirection(direction);
            }
            else
            {
                GenerateTargetPosition();
            }
        }

        public override void Enabled()
        {
            base.Enabled();

            GenerateTargetPosition();
        }

        private Vector3 GenerateTargetPosition()
        {
            Vector3 randomPosition = Random.insideUnitSphere * _movementRadius + _movable.Position;
            _targetPosition = new Vector3(randomPosition.x, 0, randomPosition.z);

            return _targetPosition;
        }

        private bool IsTargetReached(float distanceToTarget) => distanceToTarget <= MinDistanceToTarget;
    }
}
