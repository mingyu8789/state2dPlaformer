using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class SK : MonoBehaviour
{
    public float moveTime;
    public float MoveSpeed;
    public float AttckSpeed;

    public SKState SKstate { get; private set; }
    public SKStateMachine SKstatemachine { get; private set; }

    public SKidle SKidle { get; private set; }
    public SKWalk SKwalk { get; private set; }

    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    [SerializeField] private Transform wallchack;
    [SerializeField] private float wallchackDistance;
    [SerializeField] private LayerMask whatIsGround;

    public int facingDir { get; private set; } = 1;

    private void Awake()
    {
        SKstatemachine = new SKStateMachine();

        SKidle = new SKidle(this, SKstatemachine, "Idle");
        SKwalk = new SKWalk(this, SKstatemachine, "Walk");

        

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        SKstatemachine.Initialize(SKidle); //초기상태 idle
    }


    private void Update()
    {
        SKstatemachine.currentState.Update();
    }

    public void Move()
    {
        rb.linearVelocity = new Vector2(MoveSpeed, rb.linearVelocityY);
    }

    public bool IsWallDetected() => Physics2D.Raycast(wallchack.position, Vector2.right * facingDir, wallchackDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallchack.position, new Vector3(wallchack.position.x + wallchackDistance, wallchack.position.y));
    }

    public void Flip()
    {
        facingDir = facingDir * -1;
        MoveSpeed = MoveSpeed * -1;
        transform.Rotate(0, 180, 0);
    }
}
