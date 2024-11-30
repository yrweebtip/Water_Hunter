using UnityEngine;

public class collisionbotol : MonoBehaviour
{
   
    public GameObject winImage; // Assign the UI Image here in the Inspector.

    private void Start()
    {
        // Ensure the win image is hidden at the start.
        if (winImage != null)
            winImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the "botol".
        if (other.gameObject.CompareTag("botol"))
        {
            // Check if this object has the "Tembok" tag.
            if (gameObject.CompareTag("water"))
            {
                // Show the Win Image.
                if (winImage != null)
                {
                    winImage.SetActive(true);
                }

                Debug.Log("You Win!");
            }
        }
    }
}