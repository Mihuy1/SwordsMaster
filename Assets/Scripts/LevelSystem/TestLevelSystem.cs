using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelSystem : MonoBehaviour
{
    [SerializeField] private XPBar xpBar;

    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        xpBar.SetLevelSystem(levelSystem);

        //Debug.Log(levelSystem.GetLevelNumber());
        //levelSystem.AddExperience(50);
        //Debug.Log(levelSystem.GetLevelNumber());
        //levelSystem.AddExperience(60);
        //Debug.Log(levelSystem.GetLevelNumber());
    }
}
