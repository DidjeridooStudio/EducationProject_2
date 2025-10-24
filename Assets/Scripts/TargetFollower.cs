using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _targetTransform;

    private void LateUpdate()
    {
        transform.position = _targetTransform.position + _offset;
    }
}
