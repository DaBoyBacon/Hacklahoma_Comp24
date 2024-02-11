using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 700f;
    public Transform player;
    public float chaseDistance = 5f;
    public LayerMask groundLayer;
    public LayerMask obstacleLayer; // LayerMask for obstacles
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public Transform obstacleCheck; // Transform to check for obstacles
    public float obstacleCheckDistance = 1f; // Distance to check for obstacles

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isChasingPlayer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= chaseDistance)
        {
            isChasingPlayer = true;
        }
        else
        {
            isChasingPlayer = false;
        }

        if (isChasingPlayer)
        {
            ChasePlayer();
        }
        else
        {
            MoveLeft();
        }
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        CheckAndJumpObstacle();
    }

    void ChasePlayer()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), step);
    }

    void CheckAndJumpObstacle()
    {
        RaycastHit2D hit = Physics2D.Raycast(obstacleCheck.position, Vector2.left, obstacleCheckDistance, obstacleLayer);
        bool shouldJump = hit.collider != null;

        if (shouldJump && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    // Optional: Visualize the ground check and obstacle check in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        if (obstacleCheck != null)
        {
            Gizmos.DrawLine(obstacleCheck.position, obstacleCheck.position + Vector3.left * obstacleCheckDistance);
        }
    }
}
