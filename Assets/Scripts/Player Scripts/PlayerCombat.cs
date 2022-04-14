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
        Debug.DrawRay(transform.position, Vector3.forward * distance);

        distance = Vector3.Distance(transform.position, enemy.transform.position);
        
        if(Physics.Raycast(player.position,enemy.transform.forward, out var hit, Mathf.Infinity))
        {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(distance <= attackRange)
                {
                    //Attack();
                    animator.SetTrigger("Attack");
                    enemyController.TakeDamage(GameManager.Instance.attackDamage);
                    nextAttackTime = Time.time + 1f / attackRate;

                }
            }
        }
    }
}

}
