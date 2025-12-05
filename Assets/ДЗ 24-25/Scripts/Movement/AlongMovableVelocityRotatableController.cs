using HW22_23;

namespace HW24_25
{
    public class AlongMovableVelocityRotatableController : Controller
    {
        private IDirectionalRotatable _rotatable;
        private IDirectionalMovable _movable;
        private IJumpable _jumpable;

        public AlongMovableVelocityRotatableController(IDirectionalRotatable rotatable, IDirectionalMovable movable, IJumpable jumpable)
        {
            _rotatable = rotatable;
            _movable = movable;
            _jumpable = jumpable;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            if (_jumpable.InJumpProcess)
                return;

            _rotatable.SetRotateDirection(_movable.CurrentVelocity);
        }
    }
}
