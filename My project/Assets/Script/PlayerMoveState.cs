using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

   

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.moveSpeed, player.rb.linearVelocityY);

        
        if(xInput == 0)
            stateMachine.ChangeState(player.idleState); // xInput이 0일 경우 대기 상태로 전환

    }


    public override void Exit()
    {
        base.Exit();
    }
}
