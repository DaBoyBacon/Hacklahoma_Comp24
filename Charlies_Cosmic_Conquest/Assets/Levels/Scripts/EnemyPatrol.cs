using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    private Transform targetPoint;
    public float speed = 2f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPoint = pointA; // Start by moving towards point A
        UpdateFacingDirection();
    }

    private void FixedUpdate()
    {
        MoveEnemy();
        if (AtTargetPoint())
        {
            SwitchTargetPoint();
            UpdateFacingDirection();
        }
    }

    private void MoveEnemy()
    {
        // Calculate the next position
        Vector2 nextPosition = Vector2.MoveTowards(rb.position, targetPoint.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(nextPosition);
    }

    private bool AtTargetPoint()
    {
        return Vector2.Distance(rb.position, targetPoint.position) < 0.1f;
    }

    private void SwitchTargetPoint()
    {
        targetPoint = targetPoint == pointA ? pointB : pointA;
    }

    private void UpdateFacingDirection()
    {
        if (targetPoint.position.x > rb.position.x)
        {
            // Target is to the right, face right
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (targetPoint.position.x < rb.position.x)
        {
            // Target is to the left, face left
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
