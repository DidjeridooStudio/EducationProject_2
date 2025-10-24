using UnityEngine;

public class Ball : MonoBehaviour
{
    private int _itemsNumber;

    public int ItemsNumber => _itemsNumber;

    private void OnTriggerEnter(Collider other)
    {
        bool isCollectibleItem = other.TryGetComponent<CollectibleItem>(out CollectibleItem collectibleItem);

        if (isCollectibleItem)
            IncreaseItemsNumber();
    }

    private void IncreaseItemsNumber() => _itemsNumber++;
}
