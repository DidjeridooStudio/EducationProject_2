using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _levelTime;

    private float _remainTime;

    private bool _isStopped = true;

    public float LevelTime => _levelTime;

    private void Awake()
    {
        _remainTime = _levelTime;
    }

    private void Update()
    {
        if (_isStopped)
            return;

        ReduceAndDisplayRemainTime();
    }

    private void ReduceAndDisplayRemainTime()
    {
        _remainTime -= Time.deltaTime;
        Debug.Log($"Îñòàëîñü ñåêóíä {(int)(_remainTime)}");
    }

    public void StartÑountdown() => _isStopped = false;

    public void Stop() => _isStopped = true;

    public bool IsTimeUp => LevelTime <= Time.time;
}
