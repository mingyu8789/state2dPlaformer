using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed;
    public float jumppose;

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

    public void PlayerlineVelocity(float xlineVelocity, float ylineVelocity)
    {
        rb.linearVelocity = new Vector2 (xlineVelocity, ylineVelocity);
    }
}
