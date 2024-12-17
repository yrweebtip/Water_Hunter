using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour

{
   
    public void Playbutton()
    {
        
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Keluar dari game");
        Application.Quit();
    }
}

