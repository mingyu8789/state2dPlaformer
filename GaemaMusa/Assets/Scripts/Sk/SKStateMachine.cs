using UnityEngine;

public class SKStateMachine
{
    public SKState currentState { get; private set; }

    public void Initialize(SKState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(SKState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
