using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public PlayerCombat playerCombat;
    public GameObject hitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(hitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);

            other.GetComponent<EnemyController>().TakeDamage(GameManager.Instance.attackDamage);

            
        }
    }
}
