using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D cc2d;
    private float horizontalMove;
    private bool verticalMove;
    public int speed;
    public float health = 3;
    public LayerMask grass;
    public float jumpPower;
    private bool isGrounded;
    private bool isFacingRight = true;
    public Animator animator;
    public Transform cutter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CapsuleCollider2D>();
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
    public void TakeDamage(float damage)
    {
    
        health -= damage;

        Vector3 theScale = cutter.localScale;
        theScale.x += 0.1015f * damage;
        cutter.localScale = theScale;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        health = 3;
        Vector3 theScale = cutter.localScale;
        theScale.x = 0;
        cutter.localScale = theScale;
        transform.position = new Vector3(-5.14177f, 0.483f);
    }
}
