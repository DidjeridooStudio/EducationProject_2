
namespace HW_31
{
    public class KillCertainEnemiesCondition : ICondition
    {
        private int _enemyToKill;
        private EnemyHolder _enemyHolder;

        public KillCertainEnemiesCondition(int enemyToKill, EnemyHolder enemyHolder)
        {
            _enemyToKill = enemyToKill;
            _enemyHolder = enemyHolder;
        }

        public bool Completed() => _enemyHolder.KilledEnemy >= _enemyToKill;
    }
}
