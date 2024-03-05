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
    private SpriteRenderer sprite;
    private bool isChasingPlayer = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

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
            sprite.flipX = false;
        }
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed / 2, rb.velocity.y);

        // Ensure the enemy faces left when moving left
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void ChasePlayer()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), step);

        // Rotate to face the player when chasing
        if (transform.position.x > player.position.x)
        {
            sprite.flipX = false;
        }
        else
        {
            // Player is to the right, face right
            sprite.flipX = true;
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
