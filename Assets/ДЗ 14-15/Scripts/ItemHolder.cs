using UnityEngine;
using static UnityEditor.Progress;

public class ItemHolder : MonoBehaviour
{
    private Item _item;

    public Item Item => _item;

    public bool IsEmpty
    {
        get
        {
            if (_item == null)
                return true;

            if (_item.gameObject == null)
                return true;

            return false;
        }
    }

    public void Occupy(Item item)
    {
        if (IsEmpty == false)
            return;

        _item = item;

        item.transform.SetParent(transform);
        item.transform.position = transform.position;
    }
}
