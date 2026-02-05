using System;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerTurnState : IState, IDisposable
{
    private readonly Vector2Int _emptyPosition = Vector2Int.one * -1;
    private readonly InputReader _inputReader;
    private readonly Grid _grid;
    private readonly IStateSwitcher _stateSwitcher;
    private readonly Camera _camera;
    private readonly IAnimation _animation;
    private readonly AudioManager _audioManager;

    public PlayerTurnState(Grid grid, IStateSwitcher stateSwitcher, IAnimation animation, AudioManager audioManager)
    {
        _grid           = grid;
        _stateSwitcher  = stateSwitcher;
        _animation      = animation;
        _camera         = Camera.main;
        _audioManager   = audioManager;

        _inputReader    = new InputReader();
        _inputReader.Click += OnTileClick;
    }

    private void OnTileClick()
    {
        Vector2Int clickPosition = _grid.WorldToGrid(_camera.ScreenToWorldPoint(_inputReader.ÑursorPosition()));

        if (_grid.IsValidPosition(clickPosition) == false || _grid.IsBlankPosition(clickPosition))
            return;

        bool isSwappable = _grid.IsSwappable(_grid.CurrentPosition, clickPosition);

        if (_grid.CurrentPosition == _emptyPosition)
        {
            _audioManager.PlayClickSound();
            _grid.SetCurrentPosition(clickPosition);
            _animation.AnimateTile(_grid.GetValueInGrid(clickPosition), 1.2f);
        }
        else if(_grid.CurrentPosition == clickPosition)
        {
            _audioManager.PlayDeselectSound();
            Deselecttile();
        }
        else if (_grid.CurrentPosition != clickPosition && isSwappable)
        {
            _grid.SetTargetPosition(clickPosition);
            _animation.AnimateTile(_grid.GetValueInGrid(_grid.CurrentPosition), 1f);
            _stateSwitcher.SwitchState<SwapTilesState>();
        }
        else if (_grid.CurrentPosition != clickPosition && !isSwappable)
        {
            _audioManager.PlayDeselectSound();
            Deselecttile();
            _grid.SetCurrentPosition(clickPosition);
            _animation.AnimateTile(_grid.GetValueInGrid(clickPosition), 1.2f);
        }
    }

    private void Deselecttile()
    {
        _animation.AnimateTile(_grid.GetValueInGrid(_grid.CurrentPosition), 1f);
        _grid.SetCurrentPosition(_emptyPosition);
        _grid.SetTargetPosition(_emptyPosition);
    }

    #region Interface

    public void Enter()
    {
        _inputReader.EnableInputs(true);
        Deselecttile();
    }

    public void Exit() => _inputReader.EnableInputs(false);
    public void Dispose() => _inputReader.Click -= OnTileClick;

    #endregion
}
