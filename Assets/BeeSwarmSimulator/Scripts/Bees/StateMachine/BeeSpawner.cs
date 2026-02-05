using UnityEngine;

public class BeeSpawner
{
    private BeesFactory _beesFactory;

    public BeeSpawner(BeesFactory beesFactory)
    {
        _beesFactory = beesFactory;
    }

    public void Spawn(BeeConfig config, Transform spawnPoint)
    {
        Bee instance = _beesFactory.Create(config, spawnPoint.position);
    }
}
