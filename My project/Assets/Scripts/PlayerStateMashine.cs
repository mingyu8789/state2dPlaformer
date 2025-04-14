using UnityEngine;

public class PlayerStateMashine
{
    public PlayerState state {  get; private set; }

    public void StartState(PlayerState _startState)
    {
        state = _startState;
        state.Enter();
    }

    public void ChangeState(PlayerState _newState)
    {
        state.Exit();
        state = _newState;
        state.Enter();
    }
}
