using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour

{
   
    public void Playbutton()
    {
        // Ganti "GameScene" dengan nama scene game Anda
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Keluar dari game");
        Application.Quit();
    }
}

