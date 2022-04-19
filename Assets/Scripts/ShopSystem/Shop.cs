using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Instance { get; private set; }

    EnemyController enemyController;
    public GameObject shopMenu;


     void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            TurnOffShop();
        }
    }

    public void TurnOnShop()
    {
        shopMenu.SetActive(true);
        //Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Debug.Log("Shop turned on!");
    }

    public void TurnOffShop()
    {
        shopMenu?.SetActive(false);

        //Time.timeScale = 1;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("Shop turned off!");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TurnOnShop();
            Debug.Log("Collider triggered, shop on!");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TurnOffShop();
            Debug.Log("Collider triggered, shop off!");
        }
    }
}
