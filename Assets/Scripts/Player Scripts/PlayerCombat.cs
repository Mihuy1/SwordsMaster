using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public AudioClip attackSound;

    public LayerMask enemyLayers;
    public EnemyController enemyController;
    public GameObject enemy;
    public GameObject Sword;
    public Transform player;

    public float attackRate = 2f;
    public float attackRange = 2f;
    public float distance;

    float nextAttackTime = 0f;


     void Start()
    {
        player = GetComponent<Transform>();
        animator = Sword.GetComponent<Animator>();
    }

    void Update()
    {
        if (enemy != null)
            distance = Vector3.Distance(transform.position, enemy.transform.position);

        else
            return;
       
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Attack");
                AudioSource source = GetComponent<AudioSource>();
                source.PlayOneShot(attackSound);
                nextAttackTime = Time.time + 1f / attackRate;

                if (distance <= attackRange)
                {
                    //enemyController.TakeDamage(GameManager.Instance.attackDamage);
                    nextAttackTime = Time.time + 1f / attackRate;

                }
            }
        }
    }
}
