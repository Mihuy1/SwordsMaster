using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

     void Update()
    {
      if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }  
    }

    public void Attack()
    {
        // Animation
        animator.SetTrigger("Attack");

        // Detect enemies in range of attack.
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyController>().TakeDamage(GameManager.Instance.attackDamage);
        }

    }

     void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
