using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currenthealth;

    private Transform target;
    public float speed = 5f;
    public float stoppingDistance;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int damage = 1;

    public ThirdPersonMovementScript _player;
    public HealthBar healthbar;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBtwAttack = startTimeBtwAttack;
    }

    // Start is called before the first frame update
    void Start()
    {

        currenthealth = maxHealth;

        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = rotation;

        if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        else if (Vector3.Distance(transform.position, target.position) < stoppingDistance)
        {
            transform.position = this.transform.position;
            Attack();
        }
    }

    public void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            _player.TakeDamage(10);
            /*healthbar.SetHealth(_player.currentHealth);*/
            Debug.Log("Attacking");

            timeBtwAttack = startTimeBtwAttack;
        } else
        {
            timeBtwAttack -= Time.deltaTime;
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

     void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemy died!");
    }

}
