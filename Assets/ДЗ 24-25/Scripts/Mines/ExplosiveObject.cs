using HW22_23;
using System.Collections;
using UnityEngine;

namespace HW24_25
{
    public class ExplosiveObject : MonoBehaviour, ITransformPosition
    {
        [SerializeField] private ParticleSystem _explodeEffect;
        [SerializeField] private float _reactionDistance;
        [SerializeField] private int _damage;
        [SerializeField] private float _timeForReaction;

        #region Interface

        public Vector3 Position => transform.position;

        #endregion

        private void Awake()
        {
            SphereCollider collider = GetComponent<SphereCollider>();
            collider.radius = _reactionDistance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                StartCoroutine(ExplodeProcess());
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawSphere(transform.position, _reactionDistance);
        }

        private IEnumerator ExplodeProcess()
        {
            _explodeEffect.Play();

            while (_timeForReaction >= 0)
            {
                _timeForReaction -= Time.deltaTime;
                yield return null;
            }

            Collider[] colliders = Physics.OverlapSphere(transform.position, _reactionDistance);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent<IDamagable>(out IDamagable damagable))
                {
                    damagable.TakeDamage(_damage);
                }
            }

            Destroy(gameObject);
        }
    }
}
