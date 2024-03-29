using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private int damage = 1;
    public PlayerHealth playerHealth;
    public PlayerScript playerMovement;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerMovement.knockBackCounter = playerMovement.knockBackTotalTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                playerMovement.knockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerMovement.knockFromRight = false;
            }

            playerHealth.TakeDamage(damage);
        }
    }

}
