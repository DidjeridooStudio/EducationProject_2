using System;
using System.Collections.Generic;

namespace HW_31
{
    public class EnemyHolder : IDisposable
    {
        private List<EvilCactus> _evilCacti = new();

        private int _killedEnemy;

        public int EnemyCount => _evilCacti.Count;
        public int KilledEnemy => _killedEnemy;
        public List<EvilCactus> EvilCacti => _evilCacti;

        public void Add(EvilCactus evilCactus)
        {
            _evilCacti.Add(evilCactus);
            evilCactus.Killed += EvilCactusOnDestroyed;
        }

        private void EvilCactusOnDestroyed(EvilCactus evilCactus)
        {
            Remove(evilCactus);
        }

        public void Remove(EvilCactus evilCactus)
        {
            _killedEnemy += 1;
            _evilCacti.Remove(evilCactus);
        }

        #region Interface

        public void Dispose()
        {
            foreach (EvilCactus evilCactus in _evilCacti)
                evilCactus.Killed -= EvilCactusOnDestroyed;
        }

        #endregion
    }
}
