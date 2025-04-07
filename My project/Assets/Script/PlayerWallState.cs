using UnityEngine;

public class PlayerWallState : PlayerState
{
    public PlayerWallState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(rb.linearVelocityX , player.wallSpeed);

        if (player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.jumpState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
