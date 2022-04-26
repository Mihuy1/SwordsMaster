using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int rewardAmount = 5;
    public int coins;
    public int attackDamage = 20;
    public TextMeshProUGUI coinAmountText;
    public GameObject notEnoughCoins;

    void Awake()
    {
        if (Instance == null) { Instance = this; } else if (Instance != this) { Destroy(this); }
        DontDestroyOnLoad(gameObject);

        coinAmountText.text = "" + coins;

        
    }


}
