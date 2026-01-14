using HW20_21;
using System.Collections;
using UnityEngine;

namespace HW_31
{
    public class CharacterView : MonoBehaviour, IInitializable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Character _character;

        private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
        private readonly int OnDeathKey = Animator.StringToHash("OnDeath");

        private const float DeadZone = 0.05f;

        private const string AlphaEdgeKey = "_AlphaEdge";
        private const float TimeforDissolve = 3f;

        private bool _isPlayerDeath;

        private SkinnedMeshRenderer[] _meshRenderers;

        #region interface

        public void Initialize()
        {
            _meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        }

        #endregion

        private void Update()
        {
            if (_character.CurrentVelocity.magnitude > DeadZone)
                StartRunning();
            else
                StopRunning();

            if (_character.IsDead && _isPlayerDeath == false)
            {
                PassAway();
            }
        }

        private void StartRunning()
        {
            _animator.SetBool(IsRunningKey, true);
        }

        private void StopRunning()
        {
            _animator.SetBool(IsRunningKey, false);
        }

        private void PassAway()
        {
            _animator.SetTrigger(OnDeathKey);
            _isPlayerDeath = true;
        }

        public void Dissolve()
        {
            StartCoroutine(DissolveProcess());
        }

        private IEnumerator DissolveProcess()
        {
            float progress = TimeforDissolve;

            while (progress > 0)
            {
                SetFloatFor(_meshRenderers, AlphaEdgeKey, 1f - progress / TimeforDissolve);
                progress -= Time.deltaTime;

                yield return null;
            }
        }

        private void SetFloatFor(SkinnedMeshRenderer[] meshRenderers, string key, float value)
        {
            foreach (SkinnedMeshRenderer renderer in meshRenderers)
                renderer.material.SetFloat(key, value);
        }
    }
}
