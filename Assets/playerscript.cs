using System;
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
    private bool isFacingRight = true;
    public Animator animator;

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
        flyChecker();
        rotationChecker();
        animationChecker();
    }

    void flyChecker()
    {
        if (cc2d.IsTouchingLayers(grass.value))
        {
            isGrounded = true;
        }
        else isGrounded = false;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void rotationChecker()
    {
        if (horizontalMove > 0 && !isFacingRight) Flip();
        if (horizontalMove < 0 && isFacingRight) Flip();
    }

    void animationChecker()
    {
        animator.SetFloat("HMove", MathF.Abs(horizontalMove));
        animator.SetFloat("VMove", rb.velocity.y);
        animator.SetBool("isGrounded", isGrounded);
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
