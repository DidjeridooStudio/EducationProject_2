using UnityEngine;

namespace HW16_17
{
    [RequireComponent(typeof(CharacterController))]
    public class MyCharacterController : MonoBehaviour
    {
        private CharacterController _characterController;

        private const float DeadZone = 0.1f;
        private const float MoveSpeed = 10f;
        private const float RotateSpeed = 600f;
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

            if (input.magnitude <= DeadZone)
            {
                return;
            }

            Vector3 normalizedDirection = input.normalized;

            ProcessMoveTo(normalizedDirection);
            ProcessRotateTo(normalizedDirection);
        }

        private void ProcessMoveTo(Vector3 direction)
        {
            _characterController.Move(direction * MoveSpeed * Time.deltaTime);
        }

        public void ProcessRotateTo(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, RotateSpeed * Time.deltaTime);
        }
    }
}
