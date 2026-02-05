using UnityEngine;
using UnityEngine.AI;

namespace BeaSwarm
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private LayerMask _groundLayerMask;

        private Controller _characterController;

        private void Awake()
        {
            NavMeshQueryFilter queryFilter = new NavMeshQueryFilter();
            queryFilter.agentTypeID = 0;
            queryFilter.areaMask = NavMesh.AllAreas;

            _characterController = new CompositeController(
                new PlayerDirectionalMovableMouseController(_character, queryFilter, _groundLayerMask),
                new AlongMovableVelocityRotatableController(_character, _character));

            _characterController.Enabled();
        }

        private void Update()
        {
            _characterController.Update(Time.deltaTime);
        }
    }
}
