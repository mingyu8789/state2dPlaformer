using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentState { get; private set; } //안에서만 접근 가능하게 해놓았다

    //초기화
    public void Initialize(PlayerState _startState)  //상시적으로 적용되는 스택을 넣어준다
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState _newState) //이러면 처음 들어오는 값이 없어서 나가고 들어간다 똑같이 다음값도 적용이 되어 다른 값도 다 한번씩 돈다
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }

}

