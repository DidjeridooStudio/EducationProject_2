using UnityEngine;

namespace HW22_23
{
    public class ExplosiveObject : MonoBehaviour, ITransformPosition
    {
        [SerializeField] private Character _character;
        [SerializeField] private ParticleSystem _explodeEffect;
        [SerializeField] private float _reactionDistance;
        [SerializeField] private int _damage;
        [SerializeField] private float _timeForReaction;

        private ExplosiveBehavior _explosiveBehavior;

        #region Interface

        public Vector3 Position => transform.position;

        #endregion

        private void Awake()
        {
            _explosiveBehavior = new ExplosiveBehavior(_character, this, _reactionDistance, _damage, _timeForReaction);
        }

        private void Update()
        {
            _explosiveBehavior.Update();

            if(_explosiveBehavior.HasStartedCountdown)
                _explodeEffect.Play();

            if (_explosiveBehavior.IsCountdownOver)
                Destroy(gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawSphere(transform.position, _reactionDistance);
        }
    }
}
