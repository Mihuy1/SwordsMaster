using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currenthealth;

    public Canvas canvas;

    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {

        currenthealth = maxHealth;

        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(25);
            Debug.Log("Enemy has taken damage!");
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
