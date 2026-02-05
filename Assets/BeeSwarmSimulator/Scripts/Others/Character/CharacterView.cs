using UnityEngine;

namespace BeaSwarm
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Character _character;

        private readonly int IsRunningKey = Animator.StringToHash("IsRunning");

        private const float DeadZone = 0.05f;

        private void Update()
        {
            if (_character.CurrentVelocity.magnitude > DeadZone)
                StartRunning();
            else
                StopRunning();
        }

        private void StartRunning()
        {
            _animator.SetBool(IsRunningKey, true);
        }

        private void StopRunning()
        {
            _animator.SetBool(IsRunningKey, false);
        }
    }
}
