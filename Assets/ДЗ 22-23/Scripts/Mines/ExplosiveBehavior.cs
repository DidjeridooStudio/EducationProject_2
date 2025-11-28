using HW16_17;
using UnityEngine;

namespace HW22_23
{
    public class ExplosiveBehavior
    {
        private ITransformPosition _transform;
        private IDamagable _damagable;
        private float _reactionDistance;
        private int _damage;
        private float _timeForReaction;

        private bool _hasStartedCountdown;
        private bool _hasDamageDone;

        public bool HasStartedCountdown => _hasStartedCountdown;
        public bool IsCountdownOver => _timeForReaction <= 0;

        public ExplosiveBehavior(IDamagable damagable, ITransformPosition transform, float reactionDistance, int damage, float timeForReaction)
        {
            _damagable = damagable;
            _transform = transform;
            _reactionDistance = reactionDistance;
            _damage = damage;
            _timeForReaction = timeForReaction;
        }

        public void Update()
        {
            if (_hasStartedCountdown)
                _timeForReaction -= Time.deltaTime;
            else
            {
                if (IsTargetInSpecifiedZone())
                    _hasStartedCountdown = true;
            }

            if(_timeForReaction <= 0)
            {
                if (_hasDamageDone)
                    return;

                if (IsTargetInSpecifiedZone())
                {
                    _damagable.TakeDamage(_damage);
                    _hasDamageDone = true;
                }
            }
        }

        private bool IsTargetInSpecifiedZone()
        {
            Vector3 direction = DistanceDetector.DirectionToTarget(_damagable.Position, _transform.Position);
            return DistanceDetector.IsTargetInSpecifiedZone(direction, _reactionDistance);
        }
    }
}
