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
        UpdateInventoryUI();
    }

    public void CraftItem(GameObject itemSlotObj)
    {
        ItemSlot itemSlot = itemSlotObj.GetComponent<ItemSlot>();

        if (itemSlot == null)
        {
            Debug.LogWarning("Item slot is null");
            return;
        }
        if (playerStats.maxInventory <= playerStats.equippedItems.Count)
        {
            Debug.Log("Inventory full");
            return;
        }

        Item item = itemSlot.item;
        if (playerStats.equippedItems.Contains(item))
        {
            Debug.Log("Already have item");
            return;
        }

        if(playerStats.redMaterials - item.redCost < 0 || playerStats.purpleMaterials - item.purpleCost < 0 || playerStats.yellowMaterials - item.yellowCost < 0)
        {
            Debug.Log("Note enought materials");
            return;
        }

        ItemSlot slotAddedTo = inventorySlots[playerStats.equippedItems.Count];

        slotAddedTo.AddItem(item);

        itemSlot.RemoveItem();
        itemSlot.BuyItem();

        playerStats.equippedItems.Add(item);

        int index = playerStats.equippedItems.Count - 1;

        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        int indexInventory = 0;
        foreach(ItemSlot slot in inventorySlots)
        {
            if (playerStats.equippedItems.Count <= indexInventory)
            {
                slot.AddItem(null);
            }
            else
            {
                slot.AddItem(playerStats.equippedItems[indexInventory]);
            }

            indexInventory++;
        }
    }

    private void OnEnable()
    {
        ItemCrafted += CraftItem;
    }
    private void OnDisable()
    {
        ItemCrafted -= CraftItem;
    }

}
