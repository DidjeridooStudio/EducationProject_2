using UnityEngine;

namespace HW_31
{
    [CreateAssetMenu(menuName = "Configs/Character Config", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public Character Prefab { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; } = 10;
        [field: SerializeField] public float RotationSpeed { get; private set; } = 900;
    }
}
