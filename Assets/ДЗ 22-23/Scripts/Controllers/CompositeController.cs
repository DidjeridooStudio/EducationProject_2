
namespace HW22_23
{
    public class CompositeController : Controller
    {
        private Controller[] _controllers;

        public CompositeController(params Controller[] controllers)
        {
            _controllers = controllers;
        }

        public override void Enabled()
        {
            base.Enabled();

            foreach (Controller controller in _controllers)
                controller.Enabled();
        }

        public override void Disabled()
        {
            base.Disabled();

            foreach (Controller controller in _controllers)
                controller.Disabled();
        }

        protected override void UpdateLogic(float deltaTime)
        {
            foreach (Controller controller in _controllers)
                controller.Update(deltaTime);
        }
    }
}
