using UnityEngine;

namespace HW22_23
{
    public class PlayerCharacterController : Controller
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        private Character _character;

        public PlayerCharacterController(Character character)
        {
            _character = character;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            Vector3 InputDirection = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

            _character.SetMoveDirection(InputDirection);
            _character.SetRotateDirection(InputDirection);
        }
    }
}
