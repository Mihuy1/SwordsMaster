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
    [SerializeField] private Animator anim;

    public AddCoins coinManager;
    private Transform target;

    public int maxHealth = 100;
    public int currenthealth;

    public float range;
    public float attackrange;
    public float startTimeBtwAttack;
    public float stoppingDistance;
    public int damage;
    public bool dead;

    private float timeBtwAttack;

    public void Start()
    {
        currenthealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBtwAttack = startTimeBtwAttack;

        dead = false;

    }

    public void Update()
    {

        if (Vector3.Distance(transform.position, target.position) <= range && dead == false)
        {
            agent.SetDestination(target.position);
            anim.SetBool("Running", true);
        }

        if (Vector3.Distance(transform.position, target.position) < stoppingDistance && dead == false)
        {
            anim.SetBool("Running", false);
            transform.position = this.transform.position;
            Attack();
        }
    }
        public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        healthbar.SetHealth(currenthealth);
        anim.SetTrigger("Hurt");

        if (currenthealth <= 0)
        {
            coinManager.AddingCoins();
            Die();
        }
    }

    public void Die()
    {
        anim.SetBool("Dead", true);
        dead = true;
        xp.levelSystem.AddExperience(110);
        Destroy(gameObject, 1f);

        _player.currentHealth = maxHealth;
        _player.healthbar.SetHealth(_player.currentHealth);
    }

    public void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            _player.TakeDamage(damage);
            anim.SetTrigger("Attack");

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
}
