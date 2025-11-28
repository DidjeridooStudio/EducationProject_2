
namespace HW22_23
{
    public abstract class Controller
    {
        private bool _isEnabled;

        public virtual void Enabled() => _isEnabled = true;
        public virtual void Disabled() => _isEnabled = false;

        public void Update(float deltaTime)
        {
            if (_isEnabled == false)
                return;

            UpdateLogic(deltaTime);
        }

        protected abstract void UpdateLogic(float deltaTime);
    }
}
