using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HW29_30
{
    public class TimerHeartView : MonoBehaviour
    {
        [SerializeField] private GameObject _heartGroup;
        [SerializeField] private GameObject _heartPrefab;

        private const float MaxHeartQuantity = 20;
        private const int OneSecond = 1;

        private int _heartQuantity;
        private List<GameObject> _heartGroupChild;
        private WaitForSeconds _waitForSeconds;
        private Coroutine _destroyHeartProcess;
        private Timer _timer;

        private bool InProcess => _destroyHeartProcess != null;

        public void Initialize(Timer timer)
        {
            _timer = timer;
            _heartGroupChild = new List<GameObject>();
            OnTimeReseted();
            _timer.RemainTime.Changed += OnTimeChanged;
            _timer.RemainTime.Reseted += OnTimeReseted;
        }

        private void OnDestroy()
        {
            _timer.RemainTime.Changed -= OnTimeChanged;
            _timer.RemainTime.Reseted -= OnTimeReseted;
        }

        private void FillHeartGroup()
        {
            _heartQuantity = (int)Mathf.Min(_timer.RemainTime.Value, MaxHeartQuantity);

            for (int i = 0; i < _heartQuantity; i++)
            {
                GameObject _heartImage = Instantiate(_heartPrefab, _heartGroup.transform);
                _heartGroupChild.Add(_heartImage);
            }

            float secondsForDestroyHeart = _timer.RemainTime.Value / _heartQuantity;

            _waitForSeconds = new WaitForSeconds(secondsForDestroyHeart);
        }

        private void OnTimeChanged()
        {
            if (InProcess == false)
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
            FillHeartGroup();
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

