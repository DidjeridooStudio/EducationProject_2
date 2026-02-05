using UnityEngine;

public class LooseState : IState
{
    private EndGamePanelView _endGamePanelView;

    public LooseState(EndGamePanelView endGamePanelView)
    {
        _endGamePanelView = endGamePanelView;
    }

    #region Interface

    public void Enter() => _endGamePanelView.ShowEndGamePanel(false);

    public void Exit()
    { }

    #endregion
}
