using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotManager : MonoBehaviour
{
    [SerializeField] List<ItemSlot> slots;
    [SerializeField] List<Item> items;

    private void Start()
    {
    }

    public void FillItemSlots()
    {
        foreach(ItemSlot slot in slots)
        {

        }
    }

}
