using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private XPBar xp;
    [SerializeField] private ThirdPersonMovementScript _player;
    [SerializeField] private HealthBar healthbar;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AddCoins coinManager;
    
    private Transform target;

    public int maxHealth = 100;
    public int currenthealth;

    public float range;
    public float attackrange;
    public float startTimeBtwAttack;
    public float stoppingDistance;

    private float timeBtwAttack;

    [SerializeField] private int killReward;

    // Start is called before the first frame update
    public void Start()
    {
        currenthealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBtwAttack = startTimeBtwAttack;

        killReward = 5;

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
            if (Vector3.Distance(transform.position, target.position) < attackrange)
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
        xp.levelSystem.AddExperience(65);
        currenthealth = maxHealth;
        _player.healthbar.SetHealth(currenthealth);

        GameManager.Instance.coins += killReward;
        coinManager.AddingCoins();
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
