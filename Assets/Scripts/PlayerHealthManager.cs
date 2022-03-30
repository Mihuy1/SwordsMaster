using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthManager : MonoBehaviour
{
    PlayerHealthManager phealthmanager;

    private float playerHealth;

    public Image healthBar;
    public Text healthtxt;
    


     void Start()
    {
        playerHealth = 100f;
    }

     void Update()
    {
        
    }
}
