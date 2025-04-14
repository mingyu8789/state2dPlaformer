using UnityEngine;

public class PlayerIdle : PlayerState
{
    public PlayerIdle(Player _player, PlayerStateMashine _statemashine, string _aniboolname)
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

        if (xInput != 0)
        {
            statemashine.ChangeState(player.Move);
        }
    }
}
