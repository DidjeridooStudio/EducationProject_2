using UnityEngine;

namespace HW16_17
{
    public class RandomWalkIdleBehavior : ImplementsMovementBehavior, IIdleBehavior
    {
        private const float ShiftTime = 1f;

        private float _time;

        public RandomWalkIdleBehavior(Transform objectTransform)
        {
            _currentTarget = RandomVector();
            _objectTransform = objectTransform;
        }

        private Vector3 RandomVector()
        {
            float x = Random.Range(-0.2f, 0.2f);
            float z = Random.Range(-0.2f, 0.2f);
            return new Vector3(x, 0, z);
        }

        #region Interface

        public void BeIdle()
        {
            ProcessMoveTo(_currentTarget);

            _time += Time.deltaTime;

            if (_time >= ShiftTime)
            {
                _currentTarget = RandomVector();
                _time = 0;
            }
        }

        #endregion
    }
}
