using UnityEngine;


//게임 개발(유니티 등): 게임 오브젝트, NPC, 플레이어 등을 지칭하는 개체.

//예: "이 게임의 모든 캐릭터는 하나의 엔티티(entity) 시스템을 통해 관리된다."
public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;

    [Header("Collision info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [Space]
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;


    protected bool isGrounded;
    protected bool isWallDetected;


    protected int facingDir = 1;
    protected bool facingRight = true;


    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    protected virtual void Update()
    {
        CollisionChecks();


    }

   


    protected virtual void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        isWallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance * facingDir, whatIsGround);
    }

    protected virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }



    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance *facingDir, wallCheck.position.y));
    }

}