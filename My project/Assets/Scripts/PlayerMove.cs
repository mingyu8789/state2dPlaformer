using UnityEngine;

public class PlayerMove : PlayerState
{
    public PlayerMove(Player _player, PlayerStateMashine _statemashine, string _aniboolname)
        : base(_player, _statemashine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.PlayerlineVelocity(xInput * player.movespeed, player.rb.linearVelocityY);

        if (xInput == 0)
        {
            statemashine.ChangeState(player.Idle);
        }
    }
}
