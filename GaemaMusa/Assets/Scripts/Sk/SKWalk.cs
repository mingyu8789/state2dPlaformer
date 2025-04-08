using UnityEngine;

public class SKWalk : SKState
{
    public SKWalk(SK _sk, SKStateMachine _stateMachine, string _animBoolName) : base(_sk, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        sk.moveTime += Time.deltaTime;

        sk.Move();

        if (sk.IsWallDetected())
        {
            sk.Flip();
        }

        if(sk.moveTime >= 5)
        {
            stateMachine.ChangeState(sk.SKidle);
            sk.moveTime = 0;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }


}
