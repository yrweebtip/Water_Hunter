using UnityEngine;

public class collisionbotol : MonoBehaviour
{
   

    public GameObject winImage; 

    private void Start()
    {
       
        if (winImage != null)
            winImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pickup"))
        {
            
            if (winImage != null)
            {
                winImage.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}