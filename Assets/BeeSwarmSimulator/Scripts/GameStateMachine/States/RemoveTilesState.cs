using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;

public class RemoveTilesState : IState, IDisposable
{
    private CancellationTokenSource _cts;

    private readonly Grid _grid;
    private readonly IStateSwitcher _stateSwitcher;
    private readonly IAnimation _animation;
    private readonly MatchFinder _matchFinder;
    private readonly AudioManager _audioManager;
    private readonly ScoreCalculator _scoreCalculator;
    private readonly FXPool _FXPool;
    private readonly GameBoard _gameBoard;

    public RemoveTilesState(Grid grid, IStateSwitcher stateSwitcher, IAnimation animation, MatchFinder matchFinder,
        AudioManager audioManager, ScoreCalculator scoreCalculator, FXPool fxPool, GameBoard gameBoard)
    {
        _grid            = grid;
        _stateSwitcher   = stateSwitcher;
        _animation       = animation;
        _matchFinder     = matchFinder;
        _audioManager    = audioManager;
        _scoreCalculator = scoreCalculator;
        _FXPool          = fxPool;
        _gameBoard       = gameBoard;
    }

    private async UniTask RemoveTiles(Grid grid, List<Tile> tilesToRemove)
    {
        foreach (Tile tile in tilesToRemove)
        {
            _audioManager.PlayRemoveSound();

            grid.SetValueInGrid(tile.transform.position, null);

            await _animation.HideTile(tile.gameObject);

            _FXPool.GetFXFromPool(tile.transform.position, _gameBoard.transform);
        }

        _cts?.Cancel();
    }

    #region Interface

    public async void Enter()
    {
        _cts = new CancellationTokenSource();
        _scoreCalculator.CalculateScoreToAdd(_matchFinder.CurrentMatchResult.MatchDirection);
        await RemoveTiles(_grid, _matchFinder.TilesToRemove);

        _stateSwitcher.SwitchState<RefillGridState>();
    }

    public void Exit()
    {
        _matchFinder.ClearTilesToRemove();
        _cts?.Cancel();
    }

    public void Dispose() => _cts?.Dispose();

    #endregion
}
