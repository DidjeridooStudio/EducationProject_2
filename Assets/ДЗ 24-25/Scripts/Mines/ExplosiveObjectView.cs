using System.Collections;
using UnityEngine;

namespace HW24_25
{
    public class ExplosiveObjectView : MonoBehaviour
    {
        [SerializeField] private ExplosiveObject _explosiveObject;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private ParticleSystem _explodeEffect;
        [SerializeField] private AudioSource _audioSource;

        private Coroutine _explodeProcess;

        private void Update()
        {
            if (_explosiveObject.IsCountDownOver && _explodeProcess == null)
                _explodeProcess = StartCoroutine(ExplodeProcess());
        }

        private IEnumerator ExplodeProcess()
        {
            _explodeEffect.Play();
            _audioSource.Play();

            _meshRenderer.enabled = false;

            while (_audioSource.isPlaying || _explodeEffect.isPlaying)
                yield return null;

            Destroy(gameObject);
        }
    }
}
