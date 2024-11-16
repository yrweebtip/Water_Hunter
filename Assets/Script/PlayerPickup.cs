using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPoint;  // Titik untuk menahan objek saat diambil
    public float pickupRange = 50f; // Jarak maksimum untuk mengambil objek
    private GameObject heldObject = null; // Objek yang sedang diambil

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickup();
            }
            else
            {
                Drop();
            }
        }
    }

    // Fungsi untuk mencoba mengambil objek
    void TryPickup()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Raycast untuk mendeteksi objek di depan pemain
        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            Debug.Log("Objek terdeteksi: " + hit.collider.name); // Menampilkan nama objek yang terdeteksi

            // Pastikan objek yang terdeteksi memiliki tag "Pickup"
            if (hit.collider.CompareTag("Pickup"))
            {
                Pickup(hit.collider.gameObject);
            }
        }
    }

    // Fungsi untuk mengambil objek
    void Pickup(GameObject obj)
    {
        Debug.Log("Mengambil objek: " + obj.name); // Log saat objek diambil
        heldObject = obj;
        Rigidbody objRb = obj.GetComponent<Rigidbody>();
        objRb.isKinematic = true; // Nonaktifkan fisika saat objek dipegang
        objRb.useGravity = false; // Nonaktifkan gravitasi
        obj.transform.position = holdPoint.position; // Posisikan objek di holdPoint
        obj.transform.parent = holdPoint; // Jadikan holdPoint sebagai parent

        // Pastikan collider aktif agar objek bisa dideteksi untuk pickup
        Collider objCollider = obj.GetComponent<Collider>();
        if (objCollider != null)
        {
            objCollider.enabled = true; // Mengaktifkan collider jika perlu
        }
    }

    // Fungsi untuk menjatuhkan objek
    void Drop()
    {
        Debug.Log("Menurunkan objek: " + heldObject.name); // Log saat objek diturunkan
        Rigidbody objRb = heldObject.GetComponent<Rigidbody>();
        objRb.isKinematic = false; // Aktifkan kembali fisika
        objRb.useGravity = true;   // Aktifkan gravitasi
        heldObject.transform.parent = null; // Lepaskan parent

        // Pastikan collider tetap aktif setelah objek dilepaskan
        Collider objCollider = heldObject.GetComponent<Collider>();
        if (objCollider != null)
        {
            objCollider.enabled = true; // Mengaktifkan collider kembali
        }

        heldObject = null; // Reset heldObject untuk memungkinkan pickup lagi
    }
}


