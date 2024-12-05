using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CraftingTableInteraction : MonoBehaviour
{
    
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && AllItemsCollected())
        {
            SceneManager.LoadScene(sceneName);
            //craftingCanvas.SetActive(true);
        }
    }

    private bool AllItemsCollected()
    {
        return CollectItem.hasKerikil && CollectItem.hasArang && CollectItem.hasSpons && CollectItem.hasIjuk;
    }
}
