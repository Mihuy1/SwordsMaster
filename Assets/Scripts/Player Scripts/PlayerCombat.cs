using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public EnemyController enemyController;
    public GameObject enemy;
    public float attackRate = 2f;
    public float attackRange = 2f;
    float nextAttackTime = 0f;


    void Update()
    {

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, Mathf.Infinity))
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) <= attackRange && enemy != null)
                {
                    //Attack();
                    animator.SetTrigger("Attack");
                    enemyController.TakeDamage(GameManager.Instance.attackDamage);
                    nextAttackTime = Time.time + 1f / attackRate;
                }

            }
        }
    }


    public void Attack()
    {
        // Animation
        animator.SetTrigger("Attack");

        // Detect enemies in range of attack.
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);


        // Damage enemies
        foreach (Collider enemy in hitEnemies)
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
