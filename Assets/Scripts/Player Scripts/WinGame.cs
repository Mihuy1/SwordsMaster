using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public GameObject WinGameUI;
    public GameObject crosshair;

    WaveSystem_Wave3 waveSystem3;

    private void Update()
    {
        // Check if last enemies are alive: Show Game Win panel.
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Scene");
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
