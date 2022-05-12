using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelector : MonoBehaviour
{
    public AudioSource click;

    public BuyScript upgradeController;
    public PlayerCombat playerCombat;

    public GameObject crosshair;
    public GameObject UI;

    public AudioSource bgMusic;

    private void Start()
    {
        crosshair = GameObject.Find("Crosshair");

        Time.timeScale = 0;

        crosshair.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        bgMusic.Stop();
    }

    public void Easy()
    {
        Time.timeScale = 1;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        crosshair.SetActive(true);
        UI.SetActive(false);

        // Player stats:
        upgradeController.lifeStealAmount = 15;
        playerCombat.lifeSteal = 13;

        //Pick-up heal:
        GameManager.Instance.healAmount = 30;
        
    }

    public void Medium()
    {
        Time.timeScale = 1;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        crosshair.SetActive(true);
        UI.SetActive(false);
        bgMusic.Play();


        // Player stats:
        upgradeController.lifeStealAmount = 11;
        playerCombat.lifeSteal = 8;
        GameManager.Instance.attackDamage = 10;

        // Pick-up heal:
        GameManager.Instance.healAmount = 20;

    }

    public void Hard()
    {
        Time.timeScale = 1;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        crosshair.SetActive(true);
        UI.SetActive(false);
        bgMusic.Play();


        // Player stats:
        upgradeController.lifeStealAmount = 9;
        playerCombat.lifeSteal = 5;
        GameManager.Instance.attackDamage = 7;
        Debug.Log("Player damage: " + GameManager.Instance.attackDamage);
        Debug.Log(upgradeController.lifeStealAmount);

        // Pick-up heal:
        GameManager.Instance.healAmount = 12;
    }

    public void ClickSound()
    {
        click.Play();
    }
}
