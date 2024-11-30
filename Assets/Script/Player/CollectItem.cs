using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public static bool hasKerikil, hasArang, hasSpons, hasIjuk;
    private bool isPlayerInRange = false;
    public string itemName;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Collect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void Collect()
    {
        switch (itemName)
        {
            case "Kerikil":
                hasKerikil = true;
                break;
            case "Arang":
                hasArang = true;
                break;
            case "Spons":
                hasSpons = true;
                break;
            case "Ijuk":
                hasIjuk = true;
                break;
        }
        Debug.Log($"{itemName} telah diambil!");
        Destroy(gameObject); 
    }
}
