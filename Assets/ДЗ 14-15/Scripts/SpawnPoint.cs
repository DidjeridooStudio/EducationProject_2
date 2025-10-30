using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float _destroyTime;

    private float _time;

    private Item _item;

    public Item Item => _item;

    public Vector3 Position => transform.position;

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

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _destroyTime && _item != null)
            Destroy(_item.gameObject);
    }

    public void Occupy(Item item)
    {
        _item = item;
        _time = 0;
    }

    public void Relieve() => _item = null;
}
