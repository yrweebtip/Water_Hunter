using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image itemImage; // Menampilkan item di slot
    public string itemName; // Nama item di slot (kosong jika slot kosong)

    public void SetItem(Sprite sprite, string name)
    {
        itemImage.sprite = sprite;
        itemName = name;
        itemImage.enabled = true;
    }

    public void ClearSlot()
    {
        itemImage.sprite = null;
        itemName = null;
        itemImage.enabled = false;
    }

    public bool IsEmpty()
    {
        return string.IsNullOrEmpty(itemName);
    }
}
