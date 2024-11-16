using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 initialPosition;

    void Start()
    {
        // Simpan posisi awal item untuk berjaga-jaga jika item perlu dikembalikan ke posisi awal
        initialPosition = transform.position;
    }

    void OnMouseDown()
    {
        // Saat objek diklik, aktifkan mode dragging
        isDragging = true;
    }

    void OnMouseUp()
    {
        // Saat mouse dilepas, hentikan dragging
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            // Mengambil posisi mouse di layar
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z; // Ambil z-position di world

            // Konversi posisi mouse di layar ke posisi world
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    // Jika diperlukan, Anda bisa menambahkan logika untuk mengembalikan item ke posisi awal jika tidak ditempatkan di posisi yang benar
    public void ResetPosition()
    {
        transform.position = initialPosition;
    }
}
