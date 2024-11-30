using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    public Transform holdPoint; // Titik tempat item dipegang
    private GameObject heldItem; // Referensi ke item yang sedang dipegang

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Tombol pickup/interact
        {
            if (heldItem == null) // Jika tidak ada item yang dipegang
            {
                TryPickup();
            }
            else // Jika ada item yang dipegang
            {
                DropItem();
            }
        }
    }

    private void TryPickup()
    {
        float pickupRange = 2.0f; // Jarak maksimal untuk mengambil item
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRange);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Pickup")) // Pastikan item memiliki tag "Pickup"
            {
                PickupItem(collider.gameObject);
                return;
            }
        }
        Debug.Log("Tidak ada item untuk diambil.");
    }

    private void PickupItem(GameObject item)
    {
        heldItem = item;
        heldItem.transform.SetParent(holdPoint); // Tetapkan posisi item ke HoldPoint
        heldItem.transform.localPosition = Vector3.zero; // Reset posisi lokal item
        heldItem.transform.localRotation = Quaternion.identity; // Reset rotasi lokal item
        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Matikan fisika agar item tidak jatuh
        }
        Debug.Log("Item diambil: " + heldItem.name);
    }

    private void DropItem()
    {
        if (heldItem != null)
        {
            heldItem.transform.SetParent(null); // Lepaskan item dari HoldPoint
            Rigidbody rb = heldItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false; // Aktifkan kembali fisika
            }
            Debug.Log("Item dilepaskan: " + heldItem.name);
            heldItem = null;
        }
    }

    public bool IsHoldingItem(GameObject item)
    {
        return heldItem == item;
    }
}


