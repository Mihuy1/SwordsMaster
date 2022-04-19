using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyScript : MonoBehaviour
{
    PlayerCombat playerCombat;

    public bool[] booleans;

    private int damageCost;
    private int healthCost;
    private int damageAmount;

     void Start()
    {
        damageCost = 5;
        healthCost = 7;
        damageAmount = 2;
    }

    public void GiveDamage()
    {
        if (GameManager.Instance.coins >= damageCost && booleans[0] != true)
        {
            GameManager.Instance.coins -= damageCost;
            GameManager.Instance.coinAmountText.text = "" + GameManager.Instance.coins;
            GameManager.Instance.attackDamage += damageAmount;

            booleans[0] = true;
            Debug.Log("Damage ostos meni läpi!");
        } else
        {
            Debug.Log("Damage ostokseen ei riitä rahaa!");
        }
    }
}
