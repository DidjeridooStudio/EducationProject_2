using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Bee Config", fileName = "BeeConfig")]
public class BeeConfig : ScriptableObject
{
    [field: SerializeField] public BeesTypes Type { get; private set; }
    [field: SerializeField] public Bee Prefab { get; private set; }
    [field: SerializeField] public RarityTypes Rarity { get; private set; }
    [field: SerializeField] public int PollenCapacity { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public TokensTypes Token { get; private set; }
}
