using System;
using UnityEditor;
using UnityEngine;

public class WinState : IState
{
    private EndGamePanelView _endGamePanelView;

    public WinState(EndGamePanelView endGamePanelView)
    {
        _endGamePanelView = endGamePanelView;
    }

    #region Interface

    public void Enter() => _endGamePanelView.ShowEndGamePanel(true);

    public void Exit()
    { }

    #endregion
}
