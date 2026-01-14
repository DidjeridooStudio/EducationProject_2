using UnityEngine;

namespace HW_31
{
    [CreateAssetMenu(menuName = "Configs/Evil Cactus Config", fileName = "EvilCactusConfig")]
    public class EvilCactusConfig : ScriptableObject
    {
        [field: SerializeField] public EvilCactus Prefab { get; private set; }
    }
}
