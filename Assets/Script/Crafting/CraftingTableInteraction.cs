using UnityEngine;
using UnityEngine.SceneManagement;

public class CraftingTableInteraction : MonoBehaviour
{
    public string craftingSceneName; 
    public string afterscene1 = "Scene1.2"; 
    public string afterscene2 = "Scene2.2"; 
    public string afterscene3 = "Scene3.3";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && AllItemsCollected())
        {
            
            string currentSceneName = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("LastScene", currentSceneName); 
            PlayerPrefs.SetString("NextScene", GetNextScene(currentSceneName)); 
            PlayerPrefs.Save();

           
            SceneManager.LoadScene(craftingSceneName);
        }
    }

    private string GetNextScene(string currentScene)
    {
        
        if (currentScene == "Level 1")
        {
            return afterscene1; 
        }
        else if (currentScene == "Level 2")
        {
            return afterscene2; 
        }
        else if (currentScene == "Level 3")
        {
            return afterscene3; 
        }
        return "";
    }

    private bool AllItemsCollected()
    {
        return CollectItem.hasKerikil && CollectItem.hasArang && CollectItem.hasSpons && CollectItem.hasIjuk && CollectItem.hasBotol;
    }
}

