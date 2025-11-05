using UnityEngine;

namespace HW16_17
{
    public class FearfulReactionBehavior : IReactionBehavior
    {
        private Transform _objectTransform;
        private float _currentScale;

        private float _destroyTime = 0.5f;
        private ParticleSystem _explodeEffect;

        private bool _isObjectDestroyed;

        public FearfulReactionBehavior(Transform objectTransform, ParticleSystem explodeEffect)
        {
            _objectTransform = objectTransform;
            _currentScale = objectTransform.localScale.y;

            _explodeEffect = explodeEffect;

            _isObjectDestroyed = false;
        }

        #region Interface

        public void React()
        {
            if (_isObjectDestroyed)
                return;

            if (_currentScale <= 0)
            {
                _explodeEffect.Play();
                Object.Destroy(_objectTransform.gameObject, _destroyTime);
                _isObjectDestroyed = true;
            }

            _currentScale -= Time.deltaTime;

            _objectTransform.localScale = new Vector3(_currentScale, _currentScale, _currentScale);
        }

        #endregion
    }
}
