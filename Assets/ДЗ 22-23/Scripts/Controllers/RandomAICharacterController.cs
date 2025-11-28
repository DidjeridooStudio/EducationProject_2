using UnityEngine;

namespace HW22_23
{
    public class RandomAICharacterController : Controller
    {
        private IDirectionalMovable _movable;

        private float _time;
        private float _timeToChangeDirection;

        private Vector3 _inputDirection;

        public RandomAICharacterController(IDirectionalMovable movable, float timeToChangeDirection)
        {
            _movable = movable;
            _timeToChangeDirection = timeToChangeDirection;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _time += Time.deltaTime;

            if(_time >= _timeToChangeDirection)
            {
                _inputDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                _time = 0;
            }

            _movable.SetMoveDirection(_inputDirection);
        }
    }
}
