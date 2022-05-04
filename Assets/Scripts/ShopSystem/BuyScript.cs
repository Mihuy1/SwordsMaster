using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyScript : MonoBehaviour
{
    PlayerCombat playerCombat;
    PlayerController playerController;

    public bool[] booleans;

    private int damageCost;
    private int damageAmount;
    private int healthCost;
    private int healthAmount;

     void Start()
    {
        damageCost = 10;
        healthCost = 25;
        damageAmount = 5;
    }

    public void GiveDamage()
    {
        if (GameManager.Instance.coins >= damageCost && booleans[0] != true)
        {
            GameManager.Instance.coins -= damageCost;
            GameManager.Instance.coinAmountText.text = "" + GameManager.Instance.coins;
            GameManager.Instance.attackDamage += damageAmount;

            booleans[0] = true;
            Debug.Log("Damage Upgrade went through!");
        } else if (booleans[0] != true)
        {
            Debug.Log("Not enough coins");
            
        } else if (booleans[0] == true)
        {
            Debug.Log("You have already bought damage upgrade before!");
        }
    }

    public void GiveHealth()
    {
        if (GameManager.Instance.coins >= healthCost && booleans[1] != true)
        {
            GameManager.Instance.coins -= damageCost;
            GameManager.Instance.coinAmountText.text = "" + GameManager.Instance.coins;

            playerController.maxHealth = 110;
            Debug.Log(playerController.currentHealth);

            booleans[1] = true;
            Debug.Log("Health upgrade went through!");
            // Play a sound to player to know it went through.
        }
    } 
}
