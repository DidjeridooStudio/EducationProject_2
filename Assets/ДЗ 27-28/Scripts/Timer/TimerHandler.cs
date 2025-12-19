using System;
using UnityEngine;

namespace HW27_28
{
    public class TimerHandler : MonoBehaviour
    {
        public event Action TimeChanged
        {
            add => _timer.TimeChanged += value;
            remove => _timer.TimeChanged -= value;
        }
        public event Action TimeReseted
        {
            add => _timer.TimeReseted += value;
            remove => _timer.TimeReseted -= value;
        }

        [SerializeField] private int _countdownTime;

        private const KeyCode StartTimerKey = KeyCode.Alpha1;
        private const KeyCode StopTimerKey = KeyCode.Alpha2;
        private const KeyCode ResetTimerKey = KeyCode.Alpha3;
        private const KeyCode SetTimerKey = KeyCode.Alpha4;

        private Timer _timer;

        public int RemainTime => _timer.RemainTime;

        private void Awake()
        {
            _timer = new Timer(this);
            _timer.SetTime(_countdownTime);
        }

        private void Update()
        {
            if (Input.GetKeyDown(StartTimerKey))
                _timer.StartCountdown();

            if (Input.GetKeyDown(StopTimerKey))
                _timer.StopCountdown();

            if (Input.GetKeyDown(ResetTimerKey))
                _timer.RestartCountdown();

            if (Input.GetKeyDown(SetTimerKey))
                _timer.SetTime(_countdownTime);
        }
    }
}
