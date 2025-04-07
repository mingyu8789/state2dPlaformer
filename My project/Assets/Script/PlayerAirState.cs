using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
        if (player.IsWallDetected() && player.IsLastWallDetected())
        {
            stateMachine.ChangeState(player.wallState);
        }
        if (player.IsWallDetected() && !player.IsLastWallDetected())
        {
            stateMachine.ChangeState(player.lastWallState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
