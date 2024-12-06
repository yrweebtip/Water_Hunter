using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
