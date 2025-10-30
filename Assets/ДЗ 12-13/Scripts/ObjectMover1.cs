using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectMover1 : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;

    private bool _isMoving;
    private bool _isJumping;
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
        _xInput = Input.GetAxisRaw(HorizontalAxisName);

        _isMoving = Mathf.Abs(_xInput) > _deadZone;

        if (Input.GetKeyDown(JumpingKey))
            _isJumping = true;
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
    }
}
