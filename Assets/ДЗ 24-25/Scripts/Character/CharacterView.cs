using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace HW24_25
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Character _character;

        private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
        private readonly int TakeHitKey = Animator.StringToHash("TakeHit");
        private readonly int OnDeathKey = Animator.StringToHash("OnDeath");
        private readonly int IsJumpingKey = Animator.StringToHash("IsJumping");

        private const float DeadZone = 0.05f;
        private const int InjuredHealthPercent = 30;
        private const int InjuryLayerIndex = 1;
        private const int MinLayerWeight = 0;
        private const int MaxLayerWeight = 1;
        private const string AlphaEdgeKey = "_AlphaEdge";
        private const float TimeforDissolve = 3f;

        private bool _isPlayerDeath;
        private bool _isInjuryLayer;
        private int _currentCharacterHealthValue;

        private SkinnedMeshRenderer[] _meshRenderers;

        private bool HasDamageTaken => _character.HealthValue < _currentCharacterHealthValue;
        private bool HasHealTaken => _character.HealthValue > _currentCharacterHealthValue;

        private void Awake()
        {
            _meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        }

        private void Start()
        {
            _currentCharacterHealthValue = _character.HealthValue;
        }

        private void Update()
        {
            _animator.SetBool(IsJumpingKey, _character.InJumpProcess);

            if (_character.CurrentVelocity.magnitude > DeadZone)
                StartRunning();
            else
                StopRunning();

            if(HasDamageTaken)
            {
                TakeDamage();
            }

            if (HasHealTaken)
            {
                GetHealing();
            }

            if (_currentCharacterHealthValue <= 0 && _isPlayerDeath == false)
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

        private void TakeDamage()
        {
            _animator.SetTrigger(TakeHitKey);
            _currentCharacterHealthValue = _character.HealthValue;

            if (_isInjuryLayer)
                return;

            if (_character.HealthPercent <= InjuredHealthPercent)
            {
                _animator.SetLayerWeight(InjuryLayerIndex, MaxLayerWeight);
                _isInjuryLayer = true;
            }
        }

        private void GetHealing()
        {
            _currentCharacterHealthValue = _character.HealthValue;

            if (_isInjuryLayer == false)
                return;

            if (_character.HealthPercent > InjuredHealthPercent)
            {
                _animator.SetLayerWeight(InjuryLayerIndex, MinLayerWeight);
                _isInjuryLayer = false;
            }
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
