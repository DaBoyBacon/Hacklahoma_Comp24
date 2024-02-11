using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Transform meleeRange;
    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    private int attackDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Needs animation added to this
        // animator.SetTrigger("Attack");

        // Hit box detection
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleeRange.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("HIT" + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }


    void OnDrawGizmosSelected()
    {

        if (meleeRange == null)
        {
            return;            
        }

        Gizmos.DrawWireSphere(meleeRange.position, attackRange);
    }

}
