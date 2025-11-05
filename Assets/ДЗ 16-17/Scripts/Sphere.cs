using UnityEngine;

namespace HW16_17
{
    public class Sphere : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explodeEffect;

        private IIdleBehavior _idleBehavior;
        private IReactionBehavior _reactionBehavior;
        private Transform _characterTransform;

        private const float ReactionDistance = 5f;

        public void Initialize(IIdleBehavior idleBehavior, IReactionBehavior reactionBehavior, Transform characterTransform)
        {
            _idleBehavior = idleBehavior;
            _reactionBehavior = reactionBehavior;
            _characterTransform = characterTransform;
        }

        private void Update()
        {
            Vector3 direction = DistanceDetector.DirectionToTarget(_characterTransform.position, transform.position);

            if (DistanceDetector.IsTargetInSpecifiedZone(direction, ReactionDistance))
                _reactionBehavior.React();
            else
                _idleBehavior.BeIdle();
        }
    }
}
