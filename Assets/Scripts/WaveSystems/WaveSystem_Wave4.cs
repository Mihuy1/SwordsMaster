using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem_Wave4 : MonoBehaviour
{
    public WaveSystem_Wave3 waveSystem3;

    public GameObject[] enemies;

    public bool _wave4;
    public bool firstWave;

    private void Start()
    {
        _wave4 = false;
        firstWave = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        FirstWave();
    }


    public void FirstWave()
    {
        if (_wave4 == false && waveSystem3._thirdWave == true)
        {
            enemies[0].SetActive(true);
            enemies[1].SetActive(true);
            enemies[2].SetActive(true);

            if (enemies[0] && enemies[1] && enemies[2] == null)
            _wave4 = true;
        }
    }
}
