using System.Collections;
using UnityEngine;

namespace HW_31
{
    public class RandomWalkBehavior : MonoBehaviour
    {
        [SerializeField] private int _moveSpeed;

        private Vector3 _currentTarget;

        private const float ShiftTime = 2f;

        private WaitForSeconds _waitShiftTime;

        private void Awake()
        {
            _waitShiftTime = new WaitForSeconds(ShiftTime);

            StartCoroutine(SetRandomTarger());
        }

        public void Update()
        {
            transform.Translate(_currentTarget * _moveSpeed * Time.deltaTime, Space.World);
        }

        private IEnumerator SetRandomTarger()
        {
            while(true)
            {
                yield return _waitShiftTime;

                float x = Random.Range(-0.2f, 0.2f);
                float z = Random.Range(-0.2f, 0.2f);
                _currentTarget = new Vector3(x, 0, z);
            }
        }
    }
}
