using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public HealthSlider healthSlider;
    public float currentHealth = 100f;
    public GameObject gameoverUI;
    private void Start()
    {
        gameoverUI.SetActive(false);
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        
        healthSlider.UpdateHealth(currentHealth);
        





        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0f;

        Debug.Log("Player has died.");
    }
}