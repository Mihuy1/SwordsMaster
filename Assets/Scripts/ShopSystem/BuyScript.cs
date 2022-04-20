using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyScript : MonoBehaviour
{
    PlayerCombat playerCombat;

    public bool[] booleans;

    private int damageCost;
    //private int healthCost;
    private int damageAmount;
    private int sec;

     void Start()
    {
        damageCost = 5;
        //healthCost = 7;
        damageAmount = 5;
        sec = 5;
    }

    public void GiveDamage()
    {
        if (GameManager.Instance.coins >= damageCost && booleans[0] != true)
        {
            GameManager.Instance.coins -= damageCost;
            GameManager.Instance.coinAmountText.text = "" + GameManager.Instance.coins;
            GameManager.Instance.attackDamage += damageAmount;

            booleans[0] = true;
            Debug.Log("Damage ostos meni l�pi!");
        } else if (booleans[0] != true)
        {
            // T�h�n koodi joka pist�� tekstin n�ytt��n p��lle

            Debug.Log("Ei riit� rahaa damage upgradeen!");
            
        } else if (booleans[0] == true)
        {
            // T�h�n koodi joka pist�� tekstin n�ytt��n p��lle
            Debug.Log("Olet jo ostanut damage upgraden!");
        }
    }
}
