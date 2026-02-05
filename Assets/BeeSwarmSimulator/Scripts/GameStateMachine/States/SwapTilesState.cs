using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Threading;
using UnityEngine;

public class SwapTilesState : IState, IDisposable
{
    private CancellationTokenSource _cts;
    private GameProgress _gameProgress;

    private readonly Grid _grid;
    private readonly IStateSwitcher _stateSwitcher;
    private readonly IAnimation _animation;
    private readonly MatchFinder _matchFinder;
    private readonly AudioManager _audioManager;

    public SwapTilesState(Grid grid, IStateSwitcher stateSwitcher, IAnimation animation, MatchFinder matchFinder, GameProgress gameProgress, AudioManager audioManager)
    {
        _grid           = grid;
        _stateSwitcher  = stateSwitcher;
        _animation      = animation;
        _matchFinder    = matchFinder;
        _gameProgress   = gameProgress;
        _audioManager   = audioManager;
    }

    private async UniTask SwapTiles(Vector2Int currentPos, Vector2Int targetPos)
    {
        Tile currentTile = _grid.GetValueInGrid(currentPos);
        Tile targetTile  = _grid.GetValueInGrid(targetPos);

        _animation.MoveTile(currentTile, _grid.GridToWorld(targetPos.x, targetPos.y), Ease.OutCubic);
        _animation.MoveTile(targetTile, _grid.GridToWorld(currentPos.x, currentPos.y), Ease.OutCubic);

        _grid.SetValueInGrid(currentPos, targetTile);
        _grid.SetValueInGrid(targetPos, currentTile);

        await UniTask.Delay(TimeSpan.FromSeconds(0.5f), _cts.IsCancellationRequested);

        _cts.Cancel();
    }

    #region Interface

    public async void Enter()
    {
        _cts = new CancellationTokenSource();

        _audioManager.PlayWhooshSound();

        await SwapTiles(_grid.CurrentPosition, _grid.TargetPosition);

        if(_matchFinder.CheckBoardForMatches(_grid))
        {
            _audioManager.PlayMatchSound();
            _gameProgress.SpendMoves();
            _stateSwitcher.SwitchState<RemoveTilesState>();
        }
        else
        {
            _audioManager.PlayNoMatchSound();
            await SwapTiles(_grid.TargetPosition, _grid.CurrentPosition);
            _stateSwitcher.SwitchState<PlayerTurnState>();
        }
    }

    public void Exit() => _cts?.Cancel();

    public void Dispose() => _cts?.Dispose();

    #endregion
}
