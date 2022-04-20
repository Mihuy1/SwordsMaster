using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public EnemyController enemyController;
    public PlayerCombat playerCombat;
    public GameObject hitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(hitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            Debug.Log(other.name);
            enemyController.TakeDamage(GameManager.Instance.attackDamage);
            
        }
    }
}
