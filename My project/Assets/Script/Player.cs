using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; } //초기화 값이 들어가고 바뀌는 값을 만들어주는 기계를 여기서만 건들 수 있게 넣어준다.
    public PlayerIdleState idleState { get; private set; } //가만히 있는 스택을 여기서만 건들 수 있게 넣어준다
    public PlayerMoveState moveState { get; private set; } //움직이는 스택을 여기서만 건들 수 있게 넣어준다

    private void Awake() //이건 초기화 값이 들어가는 곳이다
    {

        stateMachine = new PlayerStateMachine(); //초기화 값이 들어간다

        idleState = new PlayerIdleState(this, stateMachine, "Idle"); //가만히 있는 스택을 넣어준다
        moveState = new PlayerMoveState(this, stateMachine, "Move"); //움직이는 스택을 넣어준다
    }

    private void Start()
    {
        stateMachine.Initialize(idleState); //게임 시작시 처음상태를 대기 상태로 설정
    }


    private void Update()
    {
        stateMachine.currentState.Update(); //업데이트는 스택에 있는 스택을 업데이트 해준다
    }
}