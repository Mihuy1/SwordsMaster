using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem_Wave4 : MonoBehaviour
{
    public WaveSystem_Wave3 waveSystem3;

    public GameObject[] enemies;

    public bool _wave4;
    public bool firstWave;
    public bool firstBoss;
    public bool secondBoss;
    public bool thirdBoss;

    private void Start()
    {
        _wave4 = false;
        firstWave = false;
        firstBoss = false;
        secondBoss = false;
        thirdBoss = false;
    }

    private void Update()
    {
        FirstBoss();
    }

    public void FirstWave()
    {
        if (_wave4 == false && waveSystem3._thirdWave == true)
        {
            enemies[0].SetActive(true);
            enemies[1].SetActive(true);
            enemies[2].SetActive(true);

            _wave4 = true;
        }
    }

    public void FirstBoss()
    {
        if (_wave4 == true && firstBoss == false)
        {
            enemies[3].SetActive(true);
            firstBoss = true;
        }
    }

    public void SecondBoss()
    {
        if (firstBoss == true && secondBoss == false)
        {
            enemies[4].SetActive(true);
            secondBoss = true;
        }
    }

    public void ThirdBoss()
    {
        if (secondBoss == true && thirdBoss == false)
        {
            enemies[5].SetActive(true);
            thirdBoss = true;
        }
    }
}
