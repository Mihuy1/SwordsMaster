using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currenthealth;

    public ThirdPersonMovementScript _player;
    public HealthBar healthbar;

    public NavMeshAgent agent;

    private Transform target;

    public float range;
    public float startTimeBtwAttack;
    public float stoppingDistance;

    private float timeBtwAttack;

    // Start is called before the first frame update
    public void Start()
    {

        currenthealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBtwAttack = startTimeBtwAttack;
    }

    public void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= range)
        {
            agent.SetDestination(target.position);
        }

        if (Vector3.Distance(transform.position, target.position) < stoppingDistance)
        {
            transform.position = this.transform.position;
            Attack();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Vector3.Distance(transform.position, target.position) < range)
            {
               TakeDamage(15);
            }
        }
    }

        public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        healthbar.SetHealth(currenthealth);

        if (currenthealth <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log("+10 XP!");
    }

    public void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            _player.TakeDamage(20);
            /*healthbar.SetHealth(_player.currentHealth);*/
            Debug.Log("Attacking");

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
}
