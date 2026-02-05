using System;
using System.Collections.Generic;

public class BeesHolder : IDisposable
{
    private List<Bee> _bees = new List<Bee>();

    public int BeesCount => _bees.Count;
    public List<Bee> Bees => _bees;

    public void Add(Bee bee)
    {
        _bees.Add(bee);
    }

    public void Remove(Bee bee)
    {
        _bees.Remove(bee);
    }

    #region Interface

    public void Dispose()
    {
       
    }

    #endregion
}
