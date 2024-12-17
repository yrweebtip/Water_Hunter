using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    public Transform holdPoint; 
    private GameObject heldItem; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (heldItem == null) 
            {
                TryPickup();
            }
            else 
            {
                DropItem();
            }
        }
    }

    private void TryPickup()
    {
        float pickupRange = 2.0f; 
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRange);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Pickup")) 
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
        heldItem.transform.SetParent(holdPoint); 
        heldItem.transform.localPosition = Vector3.zero; 
        heldItem.transform.localRotation = Quaternion.identity; 
        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            Debug.Log("Item diambil: " + heldItem.name);
        }
    }

    private void DropItem()
    {
        if (heldItem != null)
        {
            heldItem.transform.SetParent(null); 
            Rigidbody rb = heldItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false; 
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


