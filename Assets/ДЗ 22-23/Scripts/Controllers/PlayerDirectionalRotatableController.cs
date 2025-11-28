using UnityEngine;

namespace HW22_23
{
    public class PlayerDirectionalRotatableController : Controller
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        private IDirectionalRotatable _rotatable;

        public PlayerDirectionalRotatableController(IDirectionalRotatable rotatable)
        {
            _rotatable = rotatable;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            Vector3 InputDirection = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

            _rotatable.SetRotateDirection(InputDirection);
        }
    }
}
