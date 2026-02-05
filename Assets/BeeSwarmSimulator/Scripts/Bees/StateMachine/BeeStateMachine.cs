using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BeeStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public BeeStateMachine()
    {
        _states = new List<IState>()
        {
            new FollowPlayerState(),
            new CollectingState(),
            new ReturningToPlayerState(),
            new GoingToHiveState(),
            new ConvertingInCombState(),
            new CombatState(),
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
