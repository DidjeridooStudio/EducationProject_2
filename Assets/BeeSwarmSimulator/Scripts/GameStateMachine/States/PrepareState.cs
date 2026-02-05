using UnityEngine;

public class PrepareState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private GameBoard _gameBoard;
    private LevelConfig _levelConfig;
    private BlankTilesSetup _blankTilesSetup;
    private BackgroundTilesSetup _backgroundTilesSetup;

    public PrepareState(IStateSwitcher stateSwitcher, GameBoard gameBoard, LevelConfig levelConfig, BlankTilesSetup blankTilesSetup, BackgroundTilesSetup backgroundTilesSetup)
    {
        _gameBoard            = gameBoard;
        _stateSwitcher        = stateSwitcher;
        _levelConfig          = levelConfig;
        _blankTilesSetup      = blankTilesSetup;
        _backgroundTilesSetup = backgroundTilesSetup;
    }

    #region Interface

    public async void Enter()
    {
        await _backgroundTilesSetup.SetupBackgrond(_gameBoard.transform, _blankTilesSetup.Blanks, _levelConfig.Width, _levelConfig.Height);
        _gameBoard.CreateBoard();
        _stateSwitcher.SwitchState<PlayerTurnState>();
    }

    public void Exit()
    {
        Debug.Log("The game started!");   
    }

    #endregion
}
