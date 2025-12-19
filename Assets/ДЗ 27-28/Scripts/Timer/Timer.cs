using System;
using System.Collections;
using UnityEngine;

namespace HW27_28
{
    public class Timer
    {
        public event Action TimeChanged;
        public event Action TimeReseted;

        private const int OneSecond = 1;

        private int _remainTime;
        private int _countdownTime;
        private WaitForSeconds _waitOneSecond;
        private Coroutine _countdownProcess;
        private MonoBehaviour _coroutineRunner;

        public Timer(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public int RemainTime => _remainTime;
        private bool InProcess => _countdownProcess != null;

        public void SetTime(int countdownTime)
        {
            _remainTime = countdownTime;
            _countdownTime = countdownTime;
            RestartCountdown();
        }

        public void StartCountdown()
        {
            _waitOneSecond = new WaitForSeconds(OneSecond);
            _countdownProcess = _coroutineRunner.StartCoroutine(CountdownProcess());
        }

        public void StopCountdown()
        {
            if (InProcess == false)
                return;

            _coroutineRunner.StopCoroutine(_countdownProcess);
            _countdownProcess = null;
        }

        public void RestartCountdown()
        {
            StopCountdown();
            _remainTime = _countdownTime;
            TimeReseted?.Invoke();
        }

        private IEnumerator CountdownProcess()
        {
            while(_remainTime != 0)
            {
                yield return _waitOneSecond;
                _remainTime -= OneSecond;
                TimeChanged?.Invoke();
            }

            _countdownProcess = null;
        }
    }
}
