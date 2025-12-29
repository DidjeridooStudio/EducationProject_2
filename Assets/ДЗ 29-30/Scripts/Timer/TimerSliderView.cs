using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

namespace HW29_30
{
    public class TimerSliderView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _countdownTMP_Text;
        [SerializeField] private Slider _slider;

        private Timer _timer;

        public void Initialize(Timer timer)
        {
            _timer = timer;
            OnTimeReseted();
            _timer.RemainTime.Changed += OnTimeChanged;
            _timer.RemainTime.Reseted += OnTimeReseted;
        }

        private void OnDestroy()
        {
            _timer.RemainTime.Changed -= OnTimeChanged;
            _timer.RemainTime.Reseted -= OnTimeReseted;
        }
        
        private void ConfigureSlider()
        {
            _slider.maxValue = _timer.RemainTime.Value;
        }

        private void ShowRemainTime()
        {
            int integerValue = (int)_timer.RemainTime.Value;
            _countdownTMP_Text.text = integerValue.ToString();
            _slider.value = _timer.RemainTime.Value;
        }

        private void OnTimeChanged()
        {
            ShowRemainTime();
        }

        private void OnTimeReseted()
        {
            ConfigureSlider();
            ShowRemainTime();
        }
    }
}
