using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public List<Slot> slots; // Hubungkan slot di Editor
    public GameObject resultItemPrefab; // Prefab untuk item hasil crafting
    public Transform resultSpawnPoint; // Posisi untuk spawn item hasil

    private readonly string[] correctOrder = { "Kerikil", "Arang", "Ijuk", "Spons" };

    public void CheckCrafting()
    {
        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (slots[i].itemName != correctOrder[i])
            {
                Debug.Log("Crafting gagal. Urutan salah.");
                return;
            }
        }

        Debug.Log("Crafting berhasil!");
        CraftResult();
    }

    private void CraftResult()
    {
        Instantiate(resultItemPrefab, resultSpawnPoint.position, Quaternion.identity);

        // Kosongkan semua slot
        foreach (var slot in slots)
        {
            slot.ClearSlot();
        }
    }
}
