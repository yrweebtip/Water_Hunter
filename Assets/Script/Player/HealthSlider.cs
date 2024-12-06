using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider healthSlider;
    // Fungsi untuk memperbarui nilai kesehatan pada

    public void UpdateHealth(float healthValue)
    {
        healthSlider.value = healthValue;
    }
}
