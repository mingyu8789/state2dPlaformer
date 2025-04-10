using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator anim {  get; private set; }
    public Rigidbody2D rb { get; private set; }

    [SerializeField] protected Transform GroundCheck;
    [SerializeField] protected float GroundCheckLine;
    [SerializeField] protected Transform WallCheck;
    [SerializeField] protected float WallCheckLine;
    [SerializeField] protected LayerMask WhatIs;

    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    protected virtual void Awack()
    {

    }

    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    protected virtual void Update()
    {

    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheck.position, new Vector2(GroundCheck.position.x, GroundCheck.position.y - GroundCheckLine);
        Gizmos.DrawLine(WallCheck.position, new Vector2(WallCheck.position.x + Wall))
    }




    public virtual bool IsGround() => Physics2D.Raycast(GroundCheck.position, Vector2.down, GroundCheckLine, WhatIs);
    public virtual bool IsWall() => Physics2D.Raycast(WallCheck.position, Vector2.right, WallCheckLine, WhatIs);
}
