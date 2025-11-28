using UnityEngine;

namespace HW22_23
{
    public class PlayerDirectionalMovableController : Controller
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        private IDirectionalMovable _movable;

        public PlayerDirectionalMovableController(IDirectionalMovable movable)
        {
            _movable = movable;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            Vector3 InputDirection = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

            _movable.SetMoveDirection(InputDirection);
        }
    }
}
