using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public EnemyController enemyController;
    public PlayerCombat playerCombat;
    //public GameObject hitParticle; // My?hemmin

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log(other.name);
            enemyController.TakeDamage(GameManager.Instance.attackDamage);
        }
    }
}
