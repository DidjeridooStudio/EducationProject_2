using UnityEngine;

public class AddingHealthItem : Item
{
    [SerializeField] private int _addedHealth;

    public override void Use(GameObject affectedGameObject)
    {
        if (affectedGameObject.TryGetComponent<Health>(out Health health))
        {
            health.Heal(_addedHealth);
        }

        base.Use(affectedGameObject);
    }
}
