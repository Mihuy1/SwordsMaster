using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public GameObject[] enemies;
    public AddCoins coinManager;
    private bool _firstWave;

     void Awake()
    {
        _firstWave = false;
    }

     void Update()
    {
        if (enemies[0] == null && enemies[1] == null && _firstWave == false)
        {
            Debug.Log("first wave ended");
            _firstWave = true;
            coinManager.CustomAmountOfCoins(20);
        }
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player") && _firstWave == false)
        {
            ActivateWave();
        }
    }

    void ActivateWave()
    {
        enemies[0].SetActive(true);
        enemies[1].SetActive(true);
        Debug.Log("First wave started!");
    }
}
