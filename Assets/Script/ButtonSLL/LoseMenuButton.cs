using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenuButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RetryButton()
    {
        SceneManager.LoadScene("Terrain_Sample");
    }
}
