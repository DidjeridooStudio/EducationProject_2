using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    [SerializeField] private List<Honeycomb> _honeycombs = new List<Honeycomb>();

    private List<Bee> _bees = new List<Bee>();

    public int BeesCount => _bees.Count;
    public List<Bee> Bees => _bees;

    public void Initialize()
    {
        BeesFactory beesFactory = new BeesFactory(this);

        BeeSpawner beeSpawner = new BeeSpawner(beesFactory);

        foreach (Honeycomb honeycomb in _honeycombs)
            honeycomb.Initialize(beeSpawner);
    }

    public void Add(Bee bee)
    {
        _bees.Add(bee);
    }

    public void Remove(Bee bee)
    {
        _bees.Remove(bee);
    }
}
