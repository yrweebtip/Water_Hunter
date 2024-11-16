using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CraftingTableInteraction : MonoBehaviour
{
    public GameObject craftingCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && AllItemsCollected())
        {
            SceneManager.LoadScene("Crafting");
            //craftingCanvas.SetActive(true);
        }
    }

    private bool AllItemsCollected()
    {
        return CollectItem.hasKerikil && CollectItem.hasArang && CollectItem.hasSpons && CollectItem.hasIjuk;
    }
}
