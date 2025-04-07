using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected Rigidbody2D rb;

    protected float xInput;
    private string animBoolName;

    protected float stateTimer;


    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true); // 애니메이션 상태 전환
        rb = player.rb; // 리지드바디 컴포넌트 가져오기
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("yVelocity", rb.linearVelocityY); // y축 속도에 따라 애니메이션 전환
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false); // 애니메이션 상태 종료
    }   
}
