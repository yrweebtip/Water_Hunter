using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Jika menggunakan Text, perlu menambahkan ini

public class InteractionUI : MonoBehaviour
{
    public GameObject interactionUI;  // Objek UI untuk interaksi
    public float interactionRange = 3f; // Jarak maksimum untuk menampilkan UI
    private bool isPlayerNearby = false; // Cek jika pemain berada dalam jarak

    void Start()
    {
        // Pastikan UI tidak terlihat di awal
        interactionUI.SetActive(false);
    }

    void Update()
    {
        // Cek jarak antara pemain dan objek ini
        if (isPlayerNearby && Vector3.Distance(transform.position, Camera.main.transform.position) <= interactionRange)
        {
            interactionUI.SetActive(true); // Tampilkan UI
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Tambahkan fungsi interaksi di sini, seperti mengambil objek
                Debug.Log("Interaksi dengan objek!");
            }
        }
        else
        {
            interactionUI.SetActive(false); // Sembunyikan UI jika terlalu jauh
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Periksa apakah pemain masuk ke area
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Sembunyikan UI jika pemain meninggalkan area
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionUI.SetActive(false); // Pastikan UI tersembunyi
        }
    }
}
