using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D cc2d;
    private float horizontalMove;
    private bool verticalMove;
    public int speed;
    public LayerMask grass;
    public float jumpPower;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        PlayerMove();
        flyCheker();
    }

    void flyCheker()
    {
        if (cc2d.IsTouchingLayers(grass.value))
        {
            isGrounded = true;
        }
        else isGrounded = false;
    }

    void PlayerInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (isGrounded)
        {
            verticalMove = Input.GetButtonDown("Jump");
        }
    }

    void PlayerMove()
    {
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        if (verticalMove)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpPower));
        }
    }
}
