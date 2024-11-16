using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public Image[] slots;
    public Sprite kerikilSprite, arangSprite, ijukSprite, sponsSprite;
    public GameObject newItem;

    public void CheckCrafting()
    {
        if (IsCorrectOrder())
        {
            Debug.Log("Item baru berhasil dibuat!");
            newItem.SetActive(true);
        }
        else
        {
            Debug.Log("Susunan salah!");
        }
    }

    private bool IsCorrectOrder()
    {
        return slots[0].sprite == kerikilSprite &&
               slots[1].sprite == arangSprite &&
               slots[2].sprite == ijukSprite &&
               slots[3].sprite == sponsSprite;
    }
}
