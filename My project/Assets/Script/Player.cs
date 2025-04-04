using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator Ani;

    private float xinput;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float jump;



    private bool flip = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Ani = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        xinput = Input.GetAxisRaw("Horizontal");
        input();
        aniContoller();
        FlipController();


    }

    private void input()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(xinput * speed , rb.linearVelocityY);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX , jump);
    }

    private void aniContoller()
    {
        bool isMove = rb.linearVelocityX != 0;   //�⺻���°� �ƴ϶�� ��

        Ani.SetBool("isMove", isMove);
    }

    private void Flip()
    {
        flip = !flip;   //!�� ���̸� �������� �����̸� ������ �ٲ�
        transform.Rotate(0 , 180 , 0);
    }

    private void FlipController()
    {
        if(rb.linearVelocityX > 0 && !flip)
        {
            Flip();
        }
        if(rb.linearVelocityX < 0 && flip)
        {
            Flip();
        }
    }
  
}
