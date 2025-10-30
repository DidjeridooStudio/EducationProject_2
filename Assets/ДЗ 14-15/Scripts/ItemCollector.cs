using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private ItemHolder _itemHolder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SpawnPoint>(out SpawnPoint spawnPoint))
        {
            CollectItemFromSpawnPoint(spawnPoint);
        }
    }

    private void CollectItemFromSpawnPoint(SpawnPoint spawnPoint)
    {
        if (spawnPoint.IsEmpty || _itemHolder.IsEmpty == false)
            return;

        _itemHolder.Occupy(spawnPoint.Item);

        spawnPoint.Relieve();
    }
}
