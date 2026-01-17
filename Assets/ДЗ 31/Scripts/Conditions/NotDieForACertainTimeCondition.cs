using UnityEngine;

namespace HW_31
{
    public class NotDieForACertainTimeCondition : ICondition
    {
        private float _currentTimeToWin;

        public NotDieForACertainTimeCondition(float currentTimeToWin)
        {
            _currentTimeToWin = currentTimeToWin;
        }

        public bool Completed()
        {
            _currentTimeToWin -= Time.deltaTime;
            return _currentTimeToWin <= 0;
        }
    }
}
