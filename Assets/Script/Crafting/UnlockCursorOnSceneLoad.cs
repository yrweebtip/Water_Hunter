using UnityEngine;



public class UnlockCursorOnSceneLoad : MonoBehaviour
{
    private void Start()
    {
        // Set cursor menjadi visible dan tidak terkunci
        Cursor.lockState = CursorLockMode.None; // Membuat kursor bebas bergerak
        Cursor.visible = true; // Menampilkan kursor
    }
}
