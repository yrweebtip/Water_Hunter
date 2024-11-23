using NUnit.Framework;
using System.Collections.Generic;
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
        string currentRecipeString = "";
        foreach (Item item in itemList)
        {
            if (item != null)
            {
                currentRecipeString += item.itemName;
            }
            else
            {
                currentRecipeString += "null";
            }
        }
        for (int i = 0; i < recipes.Length; i++)
        {
            resultslot.gameObject.gameObject.SetActive(true);
            resultslot.GetComponent<Image>().sprite = reciperesult[i].GetComponent<Image>().sprite;
            resultslot.item = reciperesult[i];
        }
    }

    public void OnCkickSlot(Slot slot)
    {
        slot.item = null;
        itemList[slot.Index] = null;
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

