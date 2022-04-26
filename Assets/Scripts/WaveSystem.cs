using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public GameObject enemies;
    private bool _firstWave;

     void Awake()
    {
        _firstWave = false;
    }

     void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player") && _firstWave == false)
        {
            enemies.SetActive(true);
            Debug.Log("First wave started!");
            // Joku teksti näyttöön mahdollisesti
        }
    }
}
