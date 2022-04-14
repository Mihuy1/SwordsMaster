using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Instance { get; private set; }

    EnemyController enemyController;
    public GameObject shop;

    public int costDamage = 5;


    public void Buy()
    {
        if (GameManager.Instance.coins >= costDamage)
        {
            GameManager.Instance.coins -= costDamage;
            GameManager.Instance.attackDamage += 20;
            Debug.Log("Added damage");
        } else
        {
            Debug.Log("Not enough coins!");
        }
    }
}
