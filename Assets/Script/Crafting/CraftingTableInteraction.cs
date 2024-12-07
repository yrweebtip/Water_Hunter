using UnityEngine;
using UnityEngine.SceneManagement;

public class CraftingTableInteraction : MonoBehaviour
{
    public string craftingSceneName; // Nama scene untuk crafting
    public string afterscene1 = "Scene1.2"; // Scene berikutnya jika asalnya dari Scene1
    public string afterscene2 = "Scene2.2"; // Scene berikutnya jika asalnya dari Scene2
    public string afterscene3 = "Scene3.3";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && AllItemsCollected())
        {
            // Simpan nama scene asal dan tujuan
            string currentSceneName = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("LastScene", currentSceneName); // Nama scene asal
            PlayerPrefs.SetString("NextScene", GetNextScene(currentSceneName)); // Nama scene tujuan
            PlayerPrefs.Save();

            // Pindah ke CraftingScene
            SceneManager.LoadScene(craftingSceneName);
        }
    }

    private string GetNextScene(string currentScene)
    {
        // Tentukan scene tujuan berdasarkan asal scene
        if (currentScene == "Level 1")
        {
            return afterscene1; // Jika asal dari Scene1
        }
        else if (currentScene == "Level 2")
        {
            return afterscene2; // Jika asal dari Scene2
        }
        else if (currentScene == "Level 3")
        {
            return afterscene3; // Jika asal dari Scene2
        }
        return ""; // Default jika nama scene tidak dikenali
    }

    private bool AllItemsCollected()
    {
        return CollectItem.hasKerikil && CollectItem.hasArang && CollectItem.hasSpons && CollectItem.hasIjuk;
    }
}

