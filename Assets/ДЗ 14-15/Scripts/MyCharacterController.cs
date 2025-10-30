using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(CharacterController))]
public class MyCharacterController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private float _deadZone = 0.1f;

    private CharacterController _characterController;

    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

        if (input.magnitude <= _deadZone)
        {
            return;
        }

        Vector3 normalizedDirection = input.normalized;

        ProcessMoveTo(normalizedDirection);
        ProcessRotateTo(normalizedDirection, _rotateSpeed);
    }

    private void ProcessMoveTo(Vector3 direction)
    {
        _characterController.Move(direction * _moveSpeed * Time.deltaTime);
    }

    public void ProcessRotateTo(Vector3 direction, float rotateSpeed)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);
    }

    public void IncreaseMoveSpeed(float value)
    {
        if (value < 0)
            Debug.LogError("ѕередано отрицательное значение в метод IncreaseMoveSpeed");

        _moveSpeed += value;

        Debug.Log($"—корость передвижени€ персонажа увеличена на {value} ед.");
    }
}
