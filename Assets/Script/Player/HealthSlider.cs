using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider healthSlider;
    

    public void UpdateHealth(float healthValue)
    {
        healthSlider.value = healthValue;
    }
}
