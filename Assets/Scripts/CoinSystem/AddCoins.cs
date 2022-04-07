using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddCoins : MonoBehaviour
{

    [SerializeField] private EnemyController enemyController;

    [SerializeField] private TextMeshProUGUI coinAmountText;

    

    public void AddingCoins()
    {
        GameManager.Instance.coins += GameManager.Instance.rewardAmount;
        GameManager.Instance.coinAmountText.text = "" + GameManager.Instance.coins;
        Debug.Log(GameManager.Instance.coins);
    }

}
