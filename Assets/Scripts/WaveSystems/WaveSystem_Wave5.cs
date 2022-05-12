using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem_Wave5 : MonoBehaviour
{
    public WinGame won;

    public WaveSystem_Wave4 waveSystem4;

    public GameObject[] enemies;

    public bool wave5 = false;

    private void Update()
    {
        if (waveSystem4.firstWave == true && enemies[0] && enemies[1] && enemies[2])
            wave5 = true;

        if (enemies[0] && enemies[1] && enemies[2] == null && wave5 != false)
        {
            won.GameWon();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        enemies[0].SetActive(true);
        enemies[1].SetActive(true);
        enemies[2].SetActive(true);
    }
}
