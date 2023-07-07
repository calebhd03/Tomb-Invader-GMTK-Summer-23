using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Image image;
    [SerializeField] Button button;



    // Start is called before the first frame update
    void Start()
    {
        AddItem();
    }

    void AddItem()
    {
        if (item == null)
            return;
        if (!item.isAvailableToCraft)
            return;

        button.interactable = true;
        image.enabled = true;
        image.sprite = item.sprite;
    }

    void CraftItem()
    {
        button.interactable = false;
        image.enabled = false;
    }
}
