using UnityEngine;

public class SpeedEnhancingItem : Item
{
    [SerializeField] private int _addedSpeed;

    public override void Use(GameObject affectedGameObject)
    {
        if (affectedGameObject.TryGetComponent<MyCharacterController>(out MyCharacterController characterController))
        {
            characterController.IncreaseMoveSpeed(_addedSpeed);
        }

        base.Use(affectedGameObject);
    }
}
