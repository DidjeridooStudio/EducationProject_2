using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _value;

    public int Value => _value;

    public void Heal(int value)
    {
        if (value < 0)
            Debug.LogError("Передано отрицательное значение в метод Heal");

        _value += value;

        Debug.Log($"Здоровье персонажа увеличено на {value} ед. ХП персонажа: {_value}");
    }
}
