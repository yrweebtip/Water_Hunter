using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CrafttingManager : MonoBehaviour
{
    private Item currentitem;
    public Image customcusor;
    public Slot[] craftingSlots;

    public List<Item> itemList;
    public string[] recipes;
    public Item[] reciperesult;
    public Slot resultslot;
    public Button backButton;
    
    private void Start()
    {
        backButton.gameObject.SetActive(false);
        itemList = new List<Item>(craftingSlots.Length);
        for (int i = 0; i < craftingSlots.Length; i++)
        {
            itemList.Add(null); // Pastikan semua elemen null di awal
        }

        foreach (Slot slot in craftingSlots)
        {
            slot.item = null;
            slot.gameObject.SetActive(false);
        }

        resultslot.item = null;
        resultslot.gameObject.SetActive(false);
    }



    private void Update()
    {
        

        if (Input.GetMouseButtonUp(0))
        {
            if (currentitem != null)
            {
                customcusor.gameObject.SetActive(false);
                Slot nearestslot = null;
                float shortestdistance = float.MaxValue;

                foreach (Slot slot in craftingSlots)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if (dist < shortestdistance)
                    {
                        shortestdistance = dist;
                        nearestslot = slot;
                    }
                }
                nearestslot.gameObject.SetActive(true);
                nearestslot.GetComponent<Image>().sprite = currentitem.GetComponent<Image>().sprite;
                nearestslot.item = currentitem;
                itemList[nearestslot.Index] = currentitem;
                currentitem = null;

                CheckForCreatedRecipes();




            }




        }



    }
    void CheckForCreatedRecipes()
    {
        resultslot.gameObject.SetActive(false);
        resultslot.item = null;
        backButton.gameObject.SetActive(false);

        // Gabungkan semua item dari slot menjadi satu string untuk dibandingkan dengan resep
        string currentRecipeString = "";
        foreach (Item item in itemList)
        {
            currentRecipeString += item != null ? item.itemName : "null";
        }

        // Periksa apakah string ini cocok dengan salah satu resep
        for (int i = 0; i < recipes.Length; i++)
        {
            if (currentRecipeString == recipes[i])
            {
                // Jika cocok, aktifkan slot hasil dan tambahkan item hasil
                resultslot.gameObject.SetActive(true);
                resultslot.GetComponent<Image>().sprite = reciperesult[i].GetComponent<Image>().sprite;
                resultslot.item = reciperesult[i];
                backButton.gameObject.SetActive(true);
                PlayerPrefs.SetInt("CraftingComplete", 1);
                PlayerPrefs.Save();
                return; // Keluar dari loop jika ada kecocokan

            }
        }
    }
    public void OnClickBackButton()
    {
        PlayerPrefs.SetInt("CraftingComplete", 1); // Simpan status selesai crafting
        PlayerPrefs.Save(); // Pastikan data tersimpan
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene 1"); // Pindah ke GameScene
    }




    public void OnCkickSlot(Slot slot)
    {
        slot.item = null;
        itemList[slot.Index] = null;
        slot.GetComponent<Image>().sprite = null; // Hapus sprite
        slot.gameObject.SetActive(false);
        CheckForCreatedRecipes();
    }



    public void OnMouseDownItem(Item item)
    {
        if (currentitem == null)
        {
            currentitem = item;
            customcusor.gameObject.SetActive(true);
            customcusor.sprite = currentitem.GetComponent<Image>().sprite;
        }
    }
   
    
}

