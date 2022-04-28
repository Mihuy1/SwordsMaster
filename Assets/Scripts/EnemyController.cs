using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private XPBar xp;
    [SerializeField] private PlayerController _player;
    [SerializeField] private HealthBar healthbar;
    [SerializeField] private NavMeshAgent agent;

    public AddCoins coinManager;
    private Transform target;

    public int maxHealth = 100;
    public int currenthealth;

    public float range;
    public float attackrange;
    public float startTimeBtwAttack;
    public float stoppingDistance;

    private float timeBtwAttack;

    public int damage;

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
    }

        public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        healthbar.SetHealth(currenthealth);

        if (currenthealth <= 0)
        {
            coinManager.AddingCoins();
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
        xp.levelSystem.AddExperience(110);

        _player.currentHealth = 100;
        _player.healthbar.SetHealth(_player.currentHealth);

    }

    public void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            _player.TakeDamage(damage);
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
