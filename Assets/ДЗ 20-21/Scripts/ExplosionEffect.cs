using UnityEngine;

namespace HW20_21
{
    public class ExplosionEffect : IShootEffect
    {
        private float _radius;
        private float _explosionForce;

        private ParticleSystem _explodeEffect;

        private const float _yDitectionPush = 1;

        public ExplosionEffect(float radius, float explosionForce, ParticleSystem explodeEffect)
        {
            _radius = radius;
            _explosionForce = explosionForce;
            _explodeEffect = explodeEffect;
        }

        #region Interface

        public void Execute(Vector3 point)
        {
            _explodeEffect.transform.position = point;
            _explodeEffect.Play();

            Collider[] targets = Physics.OverlapSphere(point, _radius);

            foreach (Collider target in targets)
            {
                if (target.TryGetComponent<IPhysicallyPushed>(out IPhysicallyPushed physicallyPushed))
                {
                    Vector3 directionToTarget = (target.transform.position - point).normalized;

                    physicallyPushed.GetPush(new Vector3(directionToTarget.x, _yDitectionPush, directionToTarget.z) * _explosionForce);

                }
            }
        }

        #endregion
    }
}
