using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("�̵� ����")]
    public float moveSpeed = 12f;
    public float jumpForce;
    public float dashSpeed;
    public float dashDuration;
    public float wallSpeed;
    public float lastWallSpeed;

    [Header("�浹 ����")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform LastwallCheck;
    [SerializeField] private float LastwallCheckDistance;

    public int facingDir { get; private set; } = 1;
    private bool facingRight = true;


    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region States
    // �÷��̾��� ���¸� �����ϴ� ���� �ӽ�
    public PlayerStateMachine stateMachine { get; private set; }

    // �÷��̾��� ���� (��� ����, �̵� ����)
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallState wallState { get; private set; }
    public PlayerLastWall lastWallState { get; private set; }

    #endregion


    private void Awake()
    {
        // ���� �ӽ� �ν��Ͻ� ����
        stateMachine = new PlayerStateMachine();

        // �� ���� �ν��Ͻ� ���� (this: �÷��̾� ��ü, stateMachine: ���� �ӽ�, "Idle"/"Move": ���� �̸�)
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallState = new PlayerWallState(this, stateMachine, "Wall");
        lastWallState = new PlayerLastWall(this, stateMachine, "LastWall");


    }

    private void Start()
    {

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // ���� ���� �� �ʱ� ���¸� ��� ����(idleState)�� ����
        stateMachine.Initialize(idleState);
    }




    private void Update()
    {
        stateMachine.currentState.Update();





    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.linearVelocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }


    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, whatIsGround);

    public bool IsLastWallDetected() => Physics2D.Raycast(LastwallCheck.position, Vector2.right, LastwallCheckDistance, whatIsGround);



    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawLine(LastwallCheck.position, new Vector3(LastwallCheck.position.x + LastwallCheckDistance, LastwallCheck.position.y));
    }


    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        wallCheckDistance = wallCheckDistance * -1;
        LastwallCheckDistance = LastwallCheckDistance * -1;
        transform.Rotate(0, 180, 0);
    }


    public void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();

    }

}