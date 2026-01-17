
namespace HW_31
{
    public class EnemiesNumberIsMoreThanCertainQuanityCondition : ICondition
    {
        private int _enemyNumbersToDefeat;
        private EnemyHolder _enemyHolder;

        public EnemiesNumberIsMoreThanCertainQuanityCondition(int enemyNumbersToDefeat, EnemyHolder enemyHolder)
        {
            _enemyNumbersToDefeat = enemyNumbersToDefeat;
            _enemyHolder = enemyHolder;
        }

        public bool Completed() => _enemyHolder.EnemyCount >= _enemyNumbersToDefeat;
    }
}
