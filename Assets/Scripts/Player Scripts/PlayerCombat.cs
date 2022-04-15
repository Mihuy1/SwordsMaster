using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public LayerMask enemyLayers;
    public EnemyController enemyController;
    public GameObject enemy;
    public Transform player;

    public float attackRate = 2f;
    public float attackRange = 2f;
    public float distance;
    float nextAttackTime = 0f;


     void Start()
    {
        player = GetComponent<Transform>();
    }

    void Update()
    {

        distance = Vector3.Distance(transform.position, enemy.transform.position);
       
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Attack");

                if (distance <= attackRange)
                {
                    enemyController.TakeDamage(GameManager.Instance.attackDamage);
                    nextAttackTime = Time.time + 1f / attackRate;

                }
            }
        }
    }
}
