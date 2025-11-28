using UnityEngine;
using UnityEngine.AI;

namespace HW22_23
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private PathPointSpawner _pointSpawner;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private float _movementRadius;
        [SerializeField] private float _downtime;

        private Controller _characterController;
        private Controller _downtimeCharacterController;
        private PlayerDirectionalMovableMouseController _mouseController;

        private float _timeToChangeControllers;

        private void Awake()
        {
            NavMeshQueryFilter queryFilter = new NavMeshQueryFilter();
            queryFilter.agentTypeID = 0;
            queryFilter.areaMask = NavMesh.AllAreas;

            _mouseController = new PlayerDirectionalMovableMouseController(_character, queryFilter, _groundLayerMask);

            _characterController = new CompositeController(
                _mouseController,
                new AlongMovableVelocityRotatableController(_character, _character));

            _downtimeCharacterController = new CompositeController(
                new PlayerRandomAINavMeshController(_character, queryFilter, _movementRadius),
                new AlongMovableVelocityRotatableController(_character, _character));

            _characterController.Enabled();
        }

        private void Update()
        {
            _characterController.Update(Time.deltaTime);
            _downtimeCharacterController.Update(Time.deltaTime);

            DisabledControllerOnDeathCharacter();

            SpawnPathPoint();

            SwitchCharacterController();
        }

        private void DisabledControllerOnDeathCharacter()
        {
            if (_character.HealthValue <= 0)
            {
                _character.SetMoveDirection(Vector3.zero);
                _characterController.Disabled();
                _downtimeCharacterController.Disabled();
            }
        }

        private void SpawnPathPoint()
        {
            if (_mouseController.HasValidTargetPosition)
            {
                _pointSpawner.Destroy();
                _pointSpawner.Create(_mouseController.TargetPosition);
            }
            else
                _pointSpawner.Destroy();
        }

        private void SwitchCharacterController()
        {
            if (Input.anyKey)
            {
                _downtimeCharacterController.Disabled();
                _characterController.Enabled();
                _timeToChangeControllers = 0;
            }
            else
            {
                if (_mouseController.HasValidTargetPosition)
                    return;

                _timeToChangeControllers += Time.deltaTime;

                if (_timeToChangeControllers >= _downtime)
                {
                    _characterController.Disabled();
                    _downtimeCharacterController.Enabled();
                    _timeToChangeControllers = 0;
                }
            }
        }
    }
}
