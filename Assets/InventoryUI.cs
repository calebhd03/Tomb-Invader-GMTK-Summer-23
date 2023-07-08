using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public ItemSlot[] inventorySlots;

    public static Action<GameObject> ItemCrafted;

    public void Start()
    {
        inventorySlots = GetComponentsInChildren<ItemSlot>();
    }

    public void CraftItem(GameObject itemSlotObj)
    {
        ItemSlot itemSlot = itemSlotObj.GetComponent<ItemSlot>();
        Debug.Log("Testing craft ");
        if(itemSlot == null) return;

        Debug.Log("Testing craft " + playerStats.maxInventory + " >= ");
        if (playerStats.maxInventory < playerStats.equippedItems.Count) return;


        ItemSlot slotAddedTo = inventorySlots[playerStats.equippedItems.Count];
        Item item = itemSlot.item;

        slotAddedTo.AddItem(item);

        itemSlot.RemoveItem();
        itemSlot.BuyItem();

        playerStats.equippedItems.Add(item);

        int index = playerStats.equippedItems.Count - 1;
        Debug.Log("Crafted + " + item.name + " : at index " + index);

        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        int indexInventory = 0;
        foreach(ItemSlot slot in inventorySlots)
        {
            slot.AddItem(playerStats.equippedItems[indexInventory]);
            Debug.Log("indexInventory " + indexInventory);
            indexInventory++;
        }
    }

    private void OnEnable()
    {
        ItemCrafted += CraftItem;
    }

}
