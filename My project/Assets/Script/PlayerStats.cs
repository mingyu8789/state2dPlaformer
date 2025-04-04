using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    private string animBoolName;


    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) //���⿡ �����ڸ� ����� �ʱ�ȭ ���� �־��ش�
    {
        this.player = _player; //���⼭ �ٲﰪ�� �ʱ�ȭ������ ��ȯ �����ش�.   
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter() //���� ���� �˷��ش�
    {
        Debug.Log("���� " + animBoolName);
    }

    public virtual void Update()    //���� �Է°��� �˷��ش�.
    {
        Debug.Log("������Ʈ " + animBoolName);
    }

    public virtual void Exit()  // ���� ���� �˷��ش�
    {
        Debug.Log("����Ʈ " + animBoolName);
    }   
}
