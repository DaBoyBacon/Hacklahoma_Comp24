using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyGroundPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D body;
    private Animator anim;
    private Transform currentPoint; // Corrected spelling
    public float speed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;

        // Optionally, remove the warning log or handle the case where the animator is not needed
        if (anim != null)
        {
            anim.SetBool("isRunning", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsCurrentPoint();

        // Check if the enemy has reached the current point
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            // Switch to the other point
            if (currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
                FlipDirection();
            }
            else
            {
                currentPoint = pointA.transform;
                FlipDirection();
            }
        }
    }

    private void MoveTowardsCurrentPoint()
    {
        // Move towards the current point
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);
    }

    private void FlipDirection()
    {
        // Flip the enemy to face towards the next point
        Vector3 currentRotation = transform.eulerAngles;
        transform.eulerAngles = new Vector3(currentRotation.x, currentRotation.y + 180, currentRotation.z);
    }

}
