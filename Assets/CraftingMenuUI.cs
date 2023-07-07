using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenuUI : MonoBehaviour
{
    [SerializeField] Transform CraftingGrid;

    ItemSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = CraftingGrid.GetComponentsInChildren<ItemSlot>();
    }

    private void UpdateUI()
    {
        foreach(ItemSlot slot in slots)
        {

        }
    }
}
