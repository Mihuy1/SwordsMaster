using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currenthealth;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            TakeDamage(50);
            Debug.Log("Enemy has taken damage!");
        }
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        UpdateHealth(currenthealth);
        
        if (currenthealth <= 0)
        {
            Die();
        }

    }

     void Die()
    {
        GameObject.Destroy(enemy);
        Debug.Log("Enemy died!");
    }

    public void UpdateHealth(int health)
    {
        currenthealth = health;
    }
}
