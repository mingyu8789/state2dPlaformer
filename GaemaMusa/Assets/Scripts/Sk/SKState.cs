using UnityEngine;

public class SKState
{
    protected SK sk;
    protected SKStateMachine stateMachine;

    protected Rigidbody2D rb;

    protected string animBoolName;

    public SKState(SK _sk, SKStateMachine _stateMachine, string _animBoolName)
    {
        this.sk = _sk;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        sk.anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
    }

    public virtual void Exit()
    {
        sk.anim.SetBool(animBoolName, false);
    }
}
