using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float movespeed;
    public float jumppose;

    public float flipdir = 1;
    public bool flipbool = true;

    public Transform Ground;
    public float GroundLine;
    public LayerMask WhatIsGround;

    public Rigidbody2D rb {  get; private set; }
    public Animator ani { get; private set; }

    public PlayerStateMashine stateMashine {  get; private set; }
    public PlayerIdle Idle { get; private set; }
    public PlayerMove Move { get; private set; }

    private void Awake()
    {
        stateMashine = new PlayerStateMashine();

        Idle = new PlayerIdle(this, stateMashine, "Idle");
        Move = new PlayerMove(this, stateMashine, "Move");
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponentInChildren<Animator>();

        stateMashine.StartState(Idle);
    }


    private void Update()
    {
        stateMashine.state.Update();
    }

    public void Flip()
    {
        flipdir = flipdir * -1;
        flipbool = !flipbool;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float _x)
    {
        if (_x > 0 && !flipbool)
            Flip();
        else if (_x < 0 && flipbool)
            Flip();
    }

    public void PlayerlineVelocity(float xlineVelocity, float ylineVelocity)
    {
        rb.linearVelocity = new Vector2 (xlineVelocity, ylineVelocity);
        FlipController(xlineVelocity);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(Ground.position, new Vector3(Ground.position.x * GroundLine, Ground.position.y));
    }
}
