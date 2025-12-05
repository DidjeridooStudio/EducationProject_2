using HW22_23;
using System.Collections;
using UnityEngine;

namespace HW24_25
{
    public class ExplosiveObject : MonoBehaviour, ITransformPosition
    {
        private const string ScaleKey = "_Scale";
        private const string FresnelEdgeKey = "_FresnelEdge";
        private const float MinPulseValue = 0;
        private const float MaxPulseValue = 1;
        private const float PulsationSpeed = 3;

        [SerializeField] private ParticleSystem _explodeEffect;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _reactionDistance;
        [SerializeField] private int _damage;
        [SerializeField] private float _timeForReaction;

        private MeshRenderer _meshRenderer;

        #region Interface

        public Vector3 Position => transform.position;

        #endregion

        private void Awake()
        {
            SphereCollider collider = GetComponent<SphereCollider>();
            collider.radius = _reactionDistance;

            _meshRenderer = GetComponent<MeshRenderer>();
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
            float progress = _timeForReaction;
            float scalePulseProgress = 0;
            float galoPulseProgress = 1;
            bool hasPulsationLimitReached = true;

            while (progress >= 0)
            {
                foreach (Material material in _meshRenderer.materials)
                {
                    material.SetFloat(ScaleKey, scalePulseProgress * 2 * 0.1f);
                    material.SetFloat(FresnelEdgeKey, galoPulseProgress * 10);
                }

                if (scalePulseProgress >= MinPulseValue && scalePulseProgress < MaxPulseValue && hasPulsationLimitReached)
                {
                    scalePulseProgress += Time.deltaTime * PulsationSpeed;
                    galoPulseProgress -= Time.deltaTime * PulsationSpeed;
                }
                else
                {
                    if (scalePulseProgress >= MaxPulseValue)
                        hasPulsationLimitReached = false;

                    scalePulseProgress -= Time.deltaTime * PulsationSpeed;
                    galoPulseProgress += Time.deltaTime * PulsationSpeed;

                    if (scalePulseProgress <= MinPulseValue)
                    {
                        hasPulsationLimitReached = true;
                        scalePulseProgress = 0;
                        galoPulseProgress = 1;
                    }

                }

                progress -= Time.deltaTime;

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

            _explodeEffect.Play();
            _audioSource.Play();

            _meshRenderer.enabled = false;

            yield return null;

            while (_audioSource.isPlaying || _explodeEffect.isPlaying)
                yield return null;

            Destroy(gameObject);
        }
    }
}
