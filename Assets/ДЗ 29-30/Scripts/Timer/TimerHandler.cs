using UnityEngine;

namespace HW29_30
{
    public class TimerHandler : MonoBehaviour
    {
        [SerializeField] private float _countdownTime;
        [SerializeField] private TimerSliderView _timerSliderView;
        [SerializeField] private TimerHeartView _timerHeartView;

        private const KeyCode StartTimerKey = KeyCode.Alpha1;
        private const KeyCode StopTimerKey = KeyCode.Alpha2;
        private const KeyCode ResetTimerKey = KeyCode.Alpha3;
        private const KeyCode SetTimerKey = KeyCode.Alpha4;

        private Timer _timer;

        private void Awake()
        {
            _timer = new Timer(this, _countdownTime);
            _timerSliderView.Initialize(_timer);
            _timerHeartView.Initialize(_timer);
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
