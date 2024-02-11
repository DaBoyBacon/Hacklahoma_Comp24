using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private int maxHealth = 1;
    public int currentHealth = 0;
    public FlyingEnemyChasing flying;
    public GroundEnemy ground;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damge)
    {
        currentHealth -= damge;

        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Debug.Log("Dead Enemy");

        // when the enemy dies, disable the components if they are not null
        if (flying != null)
        {
            flying.enabled = false;
        }

        if (ground != null)
        {
            ground.enabled = false;
        }

        // Optionally, destroy the enemy GameObject
        // Destroy(gameObject);
    }



}
