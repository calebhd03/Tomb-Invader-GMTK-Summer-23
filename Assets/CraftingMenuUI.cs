using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftingMenuUI : MonoBehaviour
{
    [SerializeField] Transform CraftingGrid;

    List<ItemSlot> craftingSlots;

    public static Action<Item> RestockItem;

    // Start is called before the first frame update
    void Start()
    {
        craftingSlots = CraftingGrid.GetComponentsInChildren<ItemSlot>().ToList<ItemSlot>();
    }

    private void OnEnable()
    {
        RestockItem += ItemRefunded;
    }
    private void OnDisable()
    {
        RestockItem -= ItemRefunded;
    }

    private void ItemRefunded(Item itemResocked)
    {
        Debug.Log("Restocking item " + itemResocked.name);
        foreach(ItemSlot itemSlot in craftingSlots)
        {
            if(itemSlot.item == itemResocked)
            {
                Debug.Log("Found item");
                itemSlot.AddItem();
            }
        }
    }


}
