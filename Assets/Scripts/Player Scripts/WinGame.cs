using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public GameObject WinGameUI;
    public GameObject crosshair;

    public WaveSystem_Wave5 waveSystem5;

    private void Start()
    {
        //waveSystem4 = GetComponent<WaveSystem_Wave4>();
    }

    public void Update()
    {
        // Check if last enemies are alive: Show Game Win panel.
        if (waveSystem5.wave5 == true)
        {
            GameWon();
        }
        
    }

    public void GameWon()
    {
        WinGameUI.SetActive(true);
        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Scene");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
