using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactionPanel; // Referensi ke Panel Interaksi
    private bool isPanelActive = false; // Status aktif atau tidaknya Panel

    void Update()
    {
        // Mengecek jika tombol F ditekan
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Mengubah status Panel: aktif atau nonaktif
            isPanelActive = !isPanelActive;
            interactionPanel.SetActive(isPanelActive); // Menampilkan atau menyembunyikan Panel
        }
    }
}

