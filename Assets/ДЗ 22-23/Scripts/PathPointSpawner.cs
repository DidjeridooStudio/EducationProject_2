using UnityEngine;

namespace HW22_23
{
    public class PathPointSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _pathPointPrefab;

        private GameObject _pathPoint;

        public bool HasPathPoint => _pathPoint != null;

        public void Create(Vector3 position)
        {
            _pathPoint = Instantiate(_pathPointPrefab, position, Quaternion.identity);
        }

        public void Destroy()
        {
            if (HasPathPoint == false)
                return;
               
            Destroy(_pathPoint);
            _pathPoint = null;
        }
    }
}
