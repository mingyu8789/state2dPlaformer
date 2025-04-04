using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; } //�ʱ�ȭ ���� ���� �ٲ�� ���� ������ִ� ��踦 ���⼭�� �ǵ� �� �ְ� �־��ش�.
    public PlayerIdleState idleState { get; private set; } //������ �ִ� ������ ���⼭�� �ǵ� �� �ְ� �־��ش�
    public PlayerMoveState moveState { get; private set; } //�����̴� ������ ���⼭�� �ǵ� �� �ְ� �־��ش�

    private void Awake() //�̰� �ʱ�ȭ ���� ���� ���̴�
    {

        stateMachine = new PlayerStateMachine(); //�ʱ�ȭ ���� ����

        idleState = new PlayerIdleState(this, stateMachine, "Idle"); //������ �ִ� ������ �־��ش�
        moveState = new PlayerMoveState(this, stateMachine, "Move"); //�����̴� ������ �־��ش�
    }

    private void Start()
    {
        stateMachine.Initialize(idleState); //���� ���۽� ó�����¸� ��� ���·� ����
    }


    private void Update()
    {
        stateMachine.currentState.Update(); //������Ʈ�� ���ÿ� �ִ� ������ ������Ʈ ���ش�
    }
}