using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void NextLevelGame()
    {
        SceneManager.LoadScene("");
    }

    // Update is called once per frame
    public void BackMainMenu()
    {
        SceneManager.LoadScene("Tampilan Awal Scene");
    }
}
