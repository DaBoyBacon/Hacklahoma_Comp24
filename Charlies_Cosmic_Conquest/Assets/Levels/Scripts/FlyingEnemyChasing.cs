using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyChasing : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;

    void Update()
    {
        // Calculate the distance between the enemy and the player
        distance = Vector3.Distance(transform.position, player.transform.position);

        // Calculate the direction to the player
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // Calculate the angle to rotate the enemy to face the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Move towards the player's position, considering both horizontal and vertical alignment
        Vector3 targetPosition = player.transform.position;

        // Move the enemy towards the player, using Vector3.MoveTowards
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Rotate the enemy to face the player
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
