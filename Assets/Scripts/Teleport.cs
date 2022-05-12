using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public WaveSystem_Wave3 waveSystem;

    public GameObject player;
    public Transform location;

    private void Update()
    {
        if (waveSystem._thirdWave == true)
        {
            player.transform.position = location.position;
        }
    }
}
