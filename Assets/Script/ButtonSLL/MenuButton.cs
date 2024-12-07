using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    
    public void NextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

  
    public void BackMainMenu()
    {
        SceneManager.LoadScene("Tampilan Awal Scene");
    }

    public void OnClickRetryButton()
    {
        // Muat ulang scene aktif
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1f;
    }
}
