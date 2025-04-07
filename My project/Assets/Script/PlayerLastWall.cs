using UnityEngine;

public class PlayerLastWall : PlayerState
{
    public PlayerLastWall(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(rb.linearVelocityX, player.lastWallSpeed);

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
