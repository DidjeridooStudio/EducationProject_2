using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotationForce;

    [SerializeField] private bool _isObjectMove;
    [SerializeField] private bool _isObjectJump;
    [SerializeField] private bool _isObjectRotate;

    private Rigidbody _rigidbody;

    private bool _isMoving;
    private bool _isJumping;
    private bool _isRotating;

    private float _xInput;

    private float _deadZone = 0.1f;

    private const KeyCode JumpingKey = KeyCode.Space;
    private const string HorizontalAxisName = "Horizontal";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessUserInput();
    }

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumping = false;
        }

        if (_isMoving)
            _rigidbody.AddForce(Vector3.right * _force * _xInput);

        if (_isRotating)
            _rigidbody.AddRelativeTorque(Vector3.forward * _rotationForce * -_xInput);
    }
    
    private void ProcessUserInput()
    {
        _xInput = Input.GetAxisRaw(HorizontalAxisName);

        bool isKeyPresssed = Mathf.Abs(_xInput) > _deadZone;

        _isMoving = isKeyPresssed && _isObjectMove;
        _isRotating = isKeyPresssed && _isObjectRotate;

        if (Input.GetKeyDown(JumpingKey) && _isObjectJump)
            _isJumping = true;
    }
}
