using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private int maxJumps = 1;
    private int jumpsRemaining = 1;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0 && isGrounded)
        {
            Jump();
        }

<<<<<<< Updated upstream
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Rotate player to face the direction of movement
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector2(0, 0); // Facing right
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector2(0, 180); // Facing left
        }
=======

>>>>>>> Stashed changes
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        jumpsRemaining --;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpsRemaining = maxJumps;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
