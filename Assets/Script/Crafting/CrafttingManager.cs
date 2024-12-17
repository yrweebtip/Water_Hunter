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
    public string sceneName;
    
    private void Start()
    {
        backButton.gameObject.SetActive(false);
        itemList = new List<Item>(craftingSlots.Length);
        for (int i = 0; i < craftingSlots.Length; i++)
        {
            itemList.Add(null); 
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

        
        string currentRecipeString = "";
        foreach (Item item in itemList)
        {
            currentRecipeString += item != null ? item.itemName : "null";
        }

        
        for (int i = 0; i < recipes.Length; i++)
        {
            if (currentRecipeString == recipes[i])
            {
                
                resultslot.gameObject.SetActive(true);
                resultslot.GetComponent<Image>().sprite = reciperesult[i].GetComponent<Image>().sprite;
                resultslot.item = reciperesult[i];
                backButton.gameObject.SetActive(true);
                PlayerPrefs.SetInt("CraftingComplete", 1);
                PlayerPrefs.Save();
                return; 

            }
        }
    }
    public void OnClickBackButton()
    {
        // Ambil nama scene tujuan dari PlayerPrefs
        string nextScene = PlayerPrefs.GetString("NextScene", "");

        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene); 
        }
       
    }





    public void OnCkickSlot(Slot slot)
    {
        slot.item = null;
        itemList[slot.Index] = null;
        slot.GetComponent<Image>().sprite = null; 
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

