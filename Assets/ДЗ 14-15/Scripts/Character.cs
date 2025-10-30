using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Character : MonoBehaviour
{
    [SerializeField] private ItemHolder _itemHolder;

    private Health _health;

    private const KeyCode UseItemKey = KeyCode.F;

    private void Awake()
    {
        _health = GetComponent<Health>();
        Debug.Log($"ХП персонажа: {_health.Value}");
    }

    private void Update()
    {
        if(Input.GetKeyDown(UseItemKey))
        {
            UseItem();
        }
    }

    private void UseItem()
    {
        if (_itemHolder.IsEmpty)
            Debug.Log("Нет предмета для использования");
        else
            _itemHolder.Item.Use(gameObject);
    }
}
