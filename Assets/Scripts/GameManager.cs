using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Timer _timer;

    [SerializeField] private List<CollectibleItem> _collectibleItems;

    private bool _isGameOver;
    private bool _isAllItemsCollect;

    private void Start()
    {
        _timer.StartСountdown();
    }

    private void Update()
    {
        if (_isGameOver)
            return;

        if (IsGameOver())
            ProcessGameOver(_isAllItemsCollect);
    }

    private bool IsGameOver()
    {
        _isAllItemsCollect = _collectibleItems.Count == _ball.ItemsNumber;

        if (_timer.IsTimeUp || _isAllItemsCollect)
            return true;

        return false;
    }

    private void ProcessGameOver(bool isAllItemsCollect)
    {
        _isGameOver = true;

        _timer.Stop();

        if (isAllItemsCollect)
            Debug.Log("Ты победил");
        else
            Debug.Log("Ты проиграл");
    }
}

