using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private static int maxJumps = 1;
    private int jumpsRemaining = 1;
    private float dbx;
    private Animator anim;
    private SpriteRenderer sprite;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        dbx = Input.GetAxisRaw("Horizontal");
        UpdateMoveAnim();
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpsRemaining > 0))
        {
            Jump();
        }


        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);


    }

    void UpdateMoveAnim() { 
        if(dbx > 0f)
        {
            anim.SetBool("moving", true);
            sprite.flipX = false;
        }
        else if(dbx < 0f)
        {
            anim.SetBool("moving", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("moving", false);
        }
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
        isGrounded = false;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged"))
        {
            isGrounded = true;
            jumpsRemaining = maxJumps;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Untagged"))
        {
           isGrounded = false;
        }
    }
}
