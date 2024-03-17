using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalMove;
    public int speed; 
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(horizontalMove);
        PlayerInput();
        PlayerMove();
    }

    void PlayerInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    void PlayerMove()
    {
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }
}
