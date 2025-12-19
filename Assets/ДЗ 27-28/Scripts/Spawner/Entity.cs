using UnityEngine;

namespace HW27_28
{
    public class Entity : MonoBehaviour
    {
        private bool _isDead;

        private float _lifeTime;

        public bool IsDead => _isDead;
        public float LifeTime => _lifeTime;

        private void Update()
        {
            _lifeTime += Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Entity>(out Entity entity))
                _isDead = true;
        }
    }
}
