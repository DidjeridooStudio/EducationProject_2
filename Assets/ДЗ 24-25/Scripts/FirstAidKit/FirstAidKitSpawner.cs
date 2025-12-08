using HW22_23;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace HW24_25
{
    public class FirstAidKitSpawner : MonoBehaviour
    {
        private const KeyCode PowerKeyCode = KeyCode.F;

        [SerializeField] private Transform _transform;
        [SerializeField] private float _spawnRadius;
        [SerializeField] private float _spawnTime;
        [SerializeField] private GameObject _firstAidKitPrefab;
        [SerializeField] private TMP_Text _tMP_Text;

        private Coroutine _spawnProcess;
        private NavMeshQueryFilter _queryFilter;
        private NavMeshPath _pathToTarget;
        private WaitForSeconds _waitForSeconds;

        public bool InProcess => _spawnProcess != null;

        private void Awake()
        {
            _pathToTarget = new NavMeshPath();

            _queryFilter = new NavMeshQueryFilter();
            _queryFilter.agentTypeID = 0;
            _queryFilter.areaMask = NavMesh.AllAreas;

            _waitForSeconds = new WaitForSeconds(_spawnTime);
        }

        private void Update()
        {
            if(Input.GetKeyDown(PowerKeyCode))
            {
                if (InProcess)
                {
                    StopCoroutine(_spawnProcess);
                    _spawnProcess = null;
                    _tMP_Text.text = "Spawn first aid kit off";
                }
                else
                {
                    _spawnProcess = StartCoroutine(SpawnProcess());
                    _tMP_Text.text = "Spawn first aid kit on";
                }
            }
        }

        private IEnumerator SpawnProcess()
        {
            while(true)
            {
                yield return _waitForSeconds;

                Vector3 _spawnPosition = Vector3.zero;

                while(_spawnPosition == Vector3.zero)
                {
                    _spawnPosition = GenerateSpawnPosition();
                    yield return null;
                }

                Instantiate(_firstAidKitPrefab, _spawnPosition, Quaternion.identity);
            }
        }

        private Vector3 GenerateSpawnPosition()
        {
            Vector3 randomPosition = Random.insideUnitSphere * _spawnRadius + _transform.position;

            if (NavMeshUtils.TryGetPath(_transform.position, randomPosition, _queryFilter, _pathToTarget))
                return new Vector3(randomPosition.x, 0, randomPosition.z);

            return Vector3.zero;
        }
    }
}
