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
        // Update nilai slider
        healthSlider.UpdateHealth(currentHealth);
        // Logika yang ingin Anda terapkan ketika pemain terkena damage





        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0f; // Memberhentikan waktu permainan
                             // Logika yang ingin Anda terapkan ketika pemain mati
        Debug.Log("Player has died.");
        // Contoh: Restart level atau tindakan setelah pemain mati
    }
}