using UnityEngine;

namespace HW22_23
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Character _character;

        private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
        private readonly int TakeHitKey = Animator.StringToHash("TakeHit");
        private readonly int OnDeathKey = Animator.StringToHash("OnDeath");

        private const float DeadZone = 0.05f;
        private const int InjuredHealthPercent = 30;
        private const int InjuryLayerIndex = 1;
        private const int MaxLayerWeight = 1;

        private bool _isPlayerDeath;
        private bool _isInjuryLayer;
        private int _currentCharacterHealthValue;

        private bool HasDamageTaken => _character.HealthValue != _currentCharacterHealthValue;

        private void Awake()
        {
            _currentCharacterHealthValue = _character.HealthValue;
        }

        private void Update()
        {
            if (_character.CurrentVelocity.magnitude > DeadZone)
                StartRunning();
            else
                StopRunning();

            if(HasDamageTaken)
            {
                TakeDamage();
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

        private void PassAway()
        {
            _animator.SetTrigger(OnDeathKey);
            _isPlayerDeath = true;
        }
    }
}
