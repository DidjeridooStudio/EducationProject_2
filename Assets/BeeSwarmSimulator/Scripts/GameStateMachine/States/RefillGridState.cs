using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class RefillGridState : IState, IDisposable
{
    private CancellationTokenSource _cts;
    private TilePool _tilePool;
    private List<Vector2Int> _tilesToRefillPos = new List<Vector2Int>();
    private GameProgress _gameProgress;

    private readonly Grid _grid;
    private readonly IStateSwitcher _stateSwitcher;
    private readonly IAnimation _animation;
    private readonly MatchFinder _matchFinder;
    private readonly Transform _parentTransform;
    private readonly AudioManager _audioManager;

    public RefillGridState(Grid grid, IStateSwitcher stateSwitcher, IAnimation animation, MatchFinder matchFinder, TilePool tilePool,
        Transform parentTransform, GameProgress gameProgress, AudioManager audioManager)
    {
        _grid               = grid;
        _stateSwitcher      = stateSwitcher;
        _animation          = animation;
        _matchFinder        = matchFinder;
        _tilePool           = tilePool;
        _parentTransform    = parentTransform;
        _gameProgress       = gameProgress;
        _audioManager       = audioManager;
    }

    private async UniTask FallTiles()
    {
        _cts = new CancellationTokenSource();

        for (int x = 0; x < _grid.Width; x++)
        {
            for (int y = 0; y < _grid.Height; y++)
            {
                if (_grid.GetValueInGrid(x, y) != null)
                    continue;

                for (int i = y + 1; i < _grid.Height; i++)
                {
                    Tile upperTile = _grid.GetValueInGrid(x, i);

                    if (upperTile == null || !upperTile.IsInteractable)
                        continue;

                    _grid.SetValueInGrid(x, y, upperTile);

                    _animation.MoveTile(upperTile, _grid.GridToWorld(x, y), Ease.InBack);

                    _grid.SetValueInGrid(x, i, null);

                    _tilesToRefillPos.Add(new Vector2Int(x, i));

                    break;
                }
            }
        }

        _audioManager.PlayWhooshSound();

        await UniTask.Delay(TimeSpan.FromSeconds(0.3f), _cts.IsCancellationRequested);

        _cts.Cancel();
    }

    private async UniTask RefillGrid()
    {
        _cts = new CancellationTokenSource();

        for (int x = 0; x < _grid.Width; x++)
        {
            for (int y = 0; y < _grid.Height; y++)
            {
                if (_grid.GetValueInGrid(x, y) != null)
                    continue;

                Tile tileFromPool = _tilePool.GetTileFromPool(_grid.GridToWorld(x, y), _parentTransform);

                tileFromPool.gameObject.SetActive(true);
                _grid.SetValueInGrid(x, y, tileFromPool);
               _animation.NonAsyncReveal(tileFromPool.gameObject, 0.3f);

                _audioManager.PlayPopSound();
            }
        }

        await UniTask.Delay(TimeSpan.FromSeconds(0.2f), _cts.IsCancellationRequested);

        _cts.Cancel();
    }

    private void CheckEndGame()
    {
        if(_gameProgress.CheckGoalScore())
            _stateSwitcher.SwitchState<WinState>();
        else if (_gameProgress.Moves <= 0)
            _stateSwitcher.SwitchState<LooseState>();
        else
            _stateSwitcher.SwitchState<PlayerTurnState>();
    }

    #region Interface

    public async void Enter()
    {
        await FallTiles();
        await RefillGrid();

        if (_matchFinder.CheckBoardForMatches(_grid))
        {
            _stateSwitcher.SwitchState<RemoveTilesState>();
            _audioManager.PlayMatchSound();
        }
        else
        {
            _audioManager.PlayNoMatchSound();
            CheckEndGame();
        }
    }

    public void Exit() => _cts?.Cancel();

    public void Dispose() => _cts?.Dispose();

    #endregion
}
