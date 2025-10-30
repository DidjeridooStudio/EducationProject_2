using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _coolDown;
    
    [SerializeField] private List<Item> _itemPrefabs;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _coolDown)
        {
            List<SpawnPoint> emptySpawnPoints = GetEmptySpawnPoints();

            if(emptySpawnPoints.Count == 0)
            {
                _time = 0;
                return;
            }

            SpawnPoint spawnPoint = emptySpawnPoints[Random.Range(0, emptySpawnPoints.Count)];

            Item item = Instantiate(_itemPrefabs[Random.Range(0, _itemPrefabs.Count)], spawnPoint.Position, Quaternion.identity);

            spawnPoint.Occupy(item);

            _time = 0;
        }
    }

    private List<SpawnPoint> GetEmptySpawnPoints()
    {
        List<SpawnPoint> emptySpawnPoints = new List<SpawnPoint>();

        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            if (spawnPoint.IsEmpty)
                emptySpawnPoints.Add(spawnPoint);
        }

        return emptySpawnPoints;
    }
}
