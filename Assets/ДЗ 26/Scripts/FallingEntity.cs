using System.Collections;
using UnityEngine;

namespace HW26
{
    public class FallingEntity : MonoBehaviour
    {
        private const int OutsideLevelZonePosition = -100;

        [SerializeField] private float _timeForReaction;
        [SerializeField] private float _fallingSpeed;

        private Coroutine _fallingProcess;

        public bool InProcess => _fallingProcess != null;

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent<IGroundCheckable>(out IGroundCheckable groundCheckable) && InProcess == false)
            {
                if (groundCheckable.IsGrounded())
                    _fallingProcess = StartCoroutine(FallingProcess());
            }
        }

        private IEnumerator FallingProcess()
        {
            yield return new WaitForSeconds(_timeForReaction);

            while (transform.position.y > OutsideLevelZonePosition)
            {
                transform.Translate(Vector2.down * _fallingSpeed * Time.deltaTime, Space.World);
                yield return null;
            }    

            Destroy(gameObject);
        }
    }
}
