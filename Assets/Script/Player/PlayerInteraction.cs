using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactionPanel; 
    private bool isPanelActive = false; 

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            isPanelActive = !isPanelActive;
            interactionPanel.SetActive(isPanelActive); 
        }
    }
}

