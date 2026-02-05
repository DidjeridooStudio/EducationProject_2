using UnityEngine;

public class Bee : MonoBehaviour
{
    private BeesTypes _type;

    private RarityTypes _rarity;

    private TokensTypes _token;

    private int _pollenCapacity;

    private int _damage;

    public void Initialize(BeeConfig beeConfig)
    {
        _type = beeConfig.Type;
        _rarity = beeConfig.Rarity;
        _token = beeConfig.Token;
        _pollenCapacity = beeConfig.PollenCapacity;
        _damage = beeConfig.Damage;
    }
}
