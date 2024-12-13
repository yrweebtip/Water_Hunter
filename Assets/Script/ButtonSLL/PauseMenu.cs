using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas; 

    private void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuCanvas.SetActive(false); 
        Time.timeScale = 1f; 
    }



}
