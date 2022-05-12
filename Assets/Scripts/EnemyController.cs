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

    public PlayerCombat playerCombat;
    public WaveSystem_Wave2 waveSystem2;

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
    public bool addedHealth;

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

        if (waveSystem2._wave2 == true && addedHealth == false)
        {
            maxHealth = 150;
            currenthealth = maxHealth;
            addedHealth = true;
            healthbar.SetHealth(maxHealth);
        } else
        {
            return;
        }
        
    }
        public void TakeDamage(int damage)
    {
        Debug.Log(maxHealth);
        currenthealth -= damage;
        healthbar.SetHealth(currenthealth);
        anim.SetTrigger("Hurt");

        if (_player.currentHealth != _player.maxHealth)
        {
            _player.currentHealth += playerCombat.lifeSteal;
            Debug.Log("lifesteal amount" + playerCombat.lifeSteal);
            _player.healthbar.SetHealth(_player.currentHealth);
        }


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

        _player.currentHealth += GameManager.Instance.deathLifeSteal;
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
