using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float _rotationForce;

    private Rigidbody _rigidbody;

    private bool _isMoving;
    private float _xInput;
    private float _deadZone = 0.1f;

    private const string HorizontalAxisName = "Horizontal";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw(HorizontalAxisName);

        _isMoving = Mathf.Abs(_xInput) > _deadZone;
    }

    private void FixedUpdate()
    {
        if (_isMoving)
            _rigidbody.AddRelativeTorque(Vector3.forward * _rotationForce * _xInput);
    }
}
