using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public GameObject[] enemies;
    private bool _firstWave;

     void Awake()
    {
        _firstWave = false;
    }

     void Update()
    {
        if (enemies[0] == null && enemies[1] == null)
        {
            Debug.Log("FIRST WAVE ENDED!");
            _firstWave = true;
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
