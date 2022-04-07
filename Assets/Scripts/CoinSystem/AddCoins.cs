using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddCoins : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;

    [SerializeField] private TextMeshProUGUI coinAmountText;
    [SerializeField] private int coins;

    private void Awake()
    {
        coins = 0;

        SetCoinAmount();
    }

    public void SetCoinAmount()
    {
        coinAmountText.text = "" + coins;
    }

    public void AddingCoins()
    {
        GameManager.Instance.coins += coins;

        coinAmountText.text = "" + coins;
    }
}
