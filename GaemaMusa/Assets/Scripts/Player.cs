using UnityEngine;

public class Player : MonoBehaviour
{
    // �÷��̾��� ���¸� �����ϴ� ���� �ӽ�
    public PlayerStateMachine stateMachine { get; private set; }

    // �÷��̾��� ���� (��� ����, �̵� ����)
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    private void Awake()
    {
        // ���� �ӽ� �ν��Ͻ� ����
        stateMachine = new PlayerStateMachine();

        // �� ���� �ν��Ͻ� ���� (this: �÷��̾� ��ü, stateMachine: ���� �ӽ�, "Idle"/"Move": ���� �̸�)
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
    }

    private void Start()
    {
        // ���� ���� �� �ʱ� ���¸� ��� ����(idleState)�� ����
        stateMachine.Initialize(idleState);
    }


    private void Update()
    {
        stateMachine.currentState.Update();
    }


}
