using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;
    //private GameBoard _gameBoard;
    //private Grid _grid;
    //private FXPool _FXPool;
    //private IAnimation _animation;
    //private MatchFinder _matchFinder;
    //private TilePool _tilePool;
    //private LevelConfig _levelConfig;
    //private GameProgress _gameProgress;
    //private AudioManager _audioManager;
    //private ScoreCalculator _scoreCalculator;
    //private BlankTilesSetup _blankTilesSetup;
    //private EndGamePanelView _endGamePanelView;
    //private BackgroundTilesSetup _backgroundTilesSetup;


    //public StateMachine(GameBoard gameBoard, Grid grid, IAnimation animation, MatchFinder matchFinder, TilePool tilePool, LevelConfig levelConfig,
    //    GameProgress gameProgress, AudioManager audioManager, ScoreCalculator scoreCalculator, BlankTilesSetup blankTilesSetup, EndGamePanelView endGamePanelView,
    //    BackgroundTilesSetup backgroundTilesSetup, FXPool fxPool)
    public StateMachine()
    {
        //_grid                   = grid;
        //_FXPool                 = fxPool;
        //_gameBoard              = gameBoard;
        //_animation              = animation;
        //_matchFinder            = matchFinder;
        //_tilePool               = tilePool;
        //_levelConfig            = levelConfig;
        //_gameProgress           = gameProgress;
        //_audioManager           = audioManager;
        //_scoreCalculator        = scoreCalculator;
        //_blankTilesSetup        = blankTilesSetup;
        //_endGamePanelView       = endGamePanelView;
        //_backgroundTilesSetup   = backgroundTilesSetup;

        _states = new List<IState>()
        {
            //new PrepareState(this, _gameBoard, _levelConfig, _blankTilesSetup, _backgroundTilesSetup),
            //new PlayerTurnState(_grid, this, _animation, _audioManager),
            //new SwapTilesState(_grid, this, _animation, _matchFinder, _gameProgress, _audioManager),
            //new RemoveTilesState(_grid, this, _animation, _matchFinder, _audioManager, _scoreCalculator, _FXPool, _gameBoard),
            //new RefillGridState(_grid, this, _animation, _matchFinder, _tilePool, _gameBoard.transform, _gameProgress, _audioManager),
            //new WinState(_endGamePanelView),
            //new LooseState(_endGamePanelView)
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    #region Interface

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = state;
        _currentState?.Enter();
    }

    #endregion
}
