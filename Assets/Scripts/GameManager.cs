using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameObject Canvas;

    public int rewardAmount = 5;
    public int coins;
    public int attackDamage = 20;
    public int deathLifeSteal = 0;

    public TextMeshProUGUI coinAmountText;

    private void Start()
    {
        if (Instance == null) { Instance = this; } else if (Instance != this) { Destroy(this); }
        DontDestroyOnLoad(gameObject);

        coinAmountText.text = "" + coins;

        Canvas = GameObject.Find("MainCanvas");
    }

}
