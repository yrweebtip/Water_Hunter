using UnityEngine;



public class UnlockCursorOnSceneLoad : MonoBehaviour
{
    private void Start()
    {
        
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    }
}
