using HW22_23;
using UnityEngine;

namespace HW_31
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Character _character;

        private Controller _characterController;

        private void Awake()
        {
            CreateControllers();
        }

        private void Update()
        {
            _characterController.Update(Time.deltaTime);

            DisabledControllerOnDeathCharacter();
        }

        private void CreateControllers()
        {
            _characterController = new CompositeController(
                new PlayerDirectionalMovableController(_character),
                new AlongMovableVelocityRotatableController(_character, _character));

            _characterController.Enabled();
        }

        private void DisabledControllerOnDeathCharacter()
        {
            if (_character.IsDead)
            {
                _character.SetMoveDirection(Vector3.zero);
                _characterController.Disabled();
            }
        }
    }
}
