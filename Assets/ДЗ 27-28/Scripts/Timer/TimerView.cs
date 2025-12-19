using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HW27_28
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TimerHandler _timerHandler;
        [SerializeField] private TMP_Text _countdownTMP_Text;
        [SerializeField] private Slider _slider;
        [SerializeField] private GameObject _heartGroup;
        [SerializeField] private GameObject _heartPrefab;

        private const int MaxHeartQuantity = 20;

        private int _heartQuantity;
        private List<GameObject> _heartGroupChild;
        private WaitForSeconds _waitForSeconds;
        private Coroutine _destroyHeartProcess;

        private bool InProcess => _destroyHeartProcess != null;

        private void Start()
        {
            _heartGroupChild = new List<GameObject>();
            OnTimeReseted();
            _timerHandler.TimeChanged += OnTimeChanged;
            _timerHandler.TimeReseted += OnTimeReseted;
        }

        private void OnDestroy()
        {
            _timerHandler.TimeChanged -= OnTimeChanged;
            _timerHandler.TimeReseted -= OnTimeReseted;
        }
        
        private void ConfigureSlider()
        {
            _slider.maxValue = _timerHandler.RemainTime;
        }

        private void FillHeartGroup()
        {
            _heartQuantity = Mathf.Min(_timerHandler.RemainTime, MaxHeartQuantity);

            for (int i = 0; i < _heartQuantity; i++)
            {
                GameObject _heartImage = Instantiate(_heartPrefab, _heartGroup.transform);
                _heartGroupChild.Add(_heartImage);
            }

            int secondsForDestroyHeart = _timerHandler.RemainTime / _heartQuantity;

            _waitForSeconds = new WaitForSeconds(secondsForDestroyHeart);
        }

        private void ShowRemainTime()
        {
            _countdownTMP_Text.text = _timerHandler.RemainTime.ToString();
            _slider.value = _timerHandler.RemainTime;
        }

        private void OnTimeChanged()
        {
            ShowRemainTime();

            if(InProcess == false)
                _destroyHeartProcess = StartCoroutine(DestroyHeartsProcess());
        }

        private IEnumerator DestroyHeartsProcess()
        {
            Destroy(_heartGroupChild[0]);
            _heartGroupChild.Remove(_heartGroupChild[0]);

            yield return _waitForSeconds;

            _destroyHeartProcess = null;
        }

        private void OnTimeReseted()
        {
            DestroyAllRemainHeart();
            ConfigureSlider();
            FillHeartGroup();
            ShowRemainTime();
            _destroyHeartProcess = null;
        }

        private void DestroyAllRemainHeart()
        {
            foreach (GameObject gameObject in _heartGroupChild)
            {
                Destroy(gameObject);
            }

            _heartGroupChild.Clear();
        }
    }
}
