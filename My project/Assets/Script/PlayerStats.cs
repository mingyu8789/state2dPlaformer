using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    private string animBoolName;


    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) //여기에 생성자를 만들어 초기화 값을 넣어준다
    {
        this.player = _player; //여기서 바뀐값에 초기화값으로 변환 시켜준다.   
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter() //들어온 값을 알려준다
    {
        Debug.Log("엔터 " + animBoolName);
    }

    public virtual void Update()    //지금 입력값을 알려준다.
    {
        Debug.Log("업데이트 " + animBoolName);
    }

    public virtual void Exit()  // 나간 값을 알려준다
    {
        Debug.Log("엑시트 " + animBoolName);
    }   
}
