using UnityEngine;
using Object = UnityEngine.Object;

public class BeesFactory
{
    private Hive _hive;

    public BeesFactory(Hive hive)
    {
        _hive = hive;
    }

    public Bee Create(BeeConfig beeConfig, Vector3 spawnPosition)
    {
        Bee instance = Object.Instantiate(beeConfig.Prefab, spawnPosition, Quaternion.identity);

        instance.Initialize(beeConfig);

        _hive.Add(instance);

        return instance;
    }
}
