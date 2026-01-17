using System;

namespace HW_31
{
    public class ConditionsFactory
    {
        public ICondition CreateVictoryConditions(LevelConfig levelConfig, EnemyHolder enemyHolder)
        {
            switch (levelConfig.VictoryConditions)
            {
                case VictoryConditions.NotDieForACertainTime:
                    return new NotDieForACertainTimeCondition(levelConfig.TimeToWin);
                case VictoryConditions.KillCertainEnemiesNumber:
                    return new KillCertainEnemiesCondition(levelConfig.EnemyToKill, enemyHolder);
                default:
                    throw new InvalidOperationException("An unprocessed victory condition");
            }
        }

        public ICondition CreateDefeatConditions(LevelConfig levelConfig, EnemyHolder enemyHolder, Character character)
        {
            switch (levelConfig.DefeatConditions)
            {
                case DefeatConditions.CharacterIsDead:
                    return new CharacterIsDeadCondition(character);
                case DefeatConditions.EnemiesNumberIsMoreThanCertainQuanity:
                    return new EnemiesNumberIsMoreThanCertainQuanityCondition(levelConfig.EnemyNumbersToDefeat, enemyHolder);
                default:
                    throw new InvalidOperationException("An unprocessed victory condition");
            }
        }
    }
}
