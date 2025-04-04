using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentState { get; private set; } //�ȿ����� ���� �����ϰ� �س��Ҵ�

    //�ʱ�ȭ
    public void Initialize(PlayerState _startState)  //��������� ����Ǵ� ������ �־��ش�
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState _newState) //�̷��� ó�� ������ ���� ��� ������ ���� �Ȱ��� �������� ������ �Ǿ� �ٸ� ���� �� �ѹ��� ����
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }

}

