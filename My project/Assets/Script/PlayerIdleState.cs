using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) 
        : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();

        if (xInput != 0)
            stateMachine.ChangeState(player.moveState); // xInput이 0이 아닐 경우 이동 상태로 전환

    }
    public override void Exit()
    {
        base.Exit();
    }


}
