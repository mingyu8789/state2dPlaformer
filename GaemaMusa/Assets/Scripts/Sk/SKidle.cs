using UnityEngine;

public class SKidle : SKState
{
    public SKidle(SK _sk, SKStateMachine _stateMachine, string _animBoolName) : base(_sk, _stateMachine, _animBoolName)
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

        if (sk.moveTime >= 3)
        {
            stateMachine.ChangeState(sk.SKwalk);
            sk.moveTime = 0;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
