using System.Collections;
using UnityEngine;

namespace HW29_30
{
    public class Timer
    {
        private ReactiveVariable<float> _remainTime;
        private float _countdownTime;
        private Coroutine _countdownProcess;
        private MonoBehaviour _coroutineRunner;

        public Timer(MonoBehaviour coroutineRunner, float countdownTime)
        {
            _coroutineRunner = coroutineRunner;
            _remainTime = new ReactiveVariable<float>(countdownTime);
            _countdownTime = countdownTime;
        }

        public IReadOnlyVariable<float> RemainTime => _remainTime;
        private bool InProcess => _countdownProcess != null;

        public void SetTime(float countdownTime)
        {
            _remainTime.InitialValue = countdownTime;
            _countdownTime = countdownTime;
            RestartCountdown();
        }

        public void StartCountdown()
        {
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
            _remainTime.Value = _countdownTime;
        }

        private IEnumerator CountdownProcess()
        {
            while(_remainTime.Value > 0)
            {
                _remainTime.Value -= Time.deltaTime;

                if(_remainTime.Value < 0)
                    _remainTime.Value = 0;

                yield return null;
            }

            _countdownProcess = null;
        }
    }
}
