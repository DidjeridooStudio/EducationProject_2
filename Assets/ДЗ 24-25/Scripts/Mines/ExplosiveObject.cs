using HW22_23;
using System.Collections;
using UnityEngine;

namespace HW24_25
{
    public class ExplosiveObject : MonoBehaviour, ITransformPosition
    {
        [SerializeField] private ExplosiveObjectView _objectView;
        [SerializeField] private float _reactionDistance;
        [SerializeField] private int _damage;
        [SerializeField] private float _timeForReaction;

        private MeshRenderer _meshRenderer;
        private Coroutine _explodeProcess;
        private ExplosivePulsation _explosivePulsation;

        private bool _isCountDownOver;

        public bool InProcess => _explodeProcess != null;
        public bool IsCountDownOver => _isCountDownOver;

        #region Interface

        public Vector3 Position => transform.position;

        #endregion

        private void Awake()
        {
            SphereCollider collider = GetComponent<SphereCollider>();
            collider.radius = _reactionDistance;

            _meshRenderer = GetComponent<MeshRenderer>();

            _explosivePulsation = new ExplosivePulsation(_meshRenderer);
        }

        private void Update()
        {
            if(InProcess)
                _explosivePulsation.Update();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamagable>(out IDamagable damagable) && InProcess == false)
            {
                _explodeProcess = StartCoroutine(ExplodeProcess());
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawSphere(transform.position, _reactionDistance);
        }

        private IEnumerator ExplodeProcess()
        {
            yield return new WaitForSeconds(_timeForReaction);

            Collider[] colliders = Physics.OverlapSphere(transform.position, _reactionDistance);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent<IDamagable>(out IDamagable damagable))
                {
                    damagable.TakeDamage(_damage);
                }
            }

            _isCountDownOver = true;
        }
    }
}
