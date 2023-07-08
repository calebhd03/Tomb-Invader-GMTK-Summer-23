using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Image image;
    [SerializeField] HoverTip hoverTip;
    [SerializeField] Button button;

    [SerializeField] bool craftingSlot = false;

    // Start is called before the first frame update
    void Start()
    {
        AddItem();
    }

    public void AddItem()
    {
        if (item == null)
            return;

        SendTipToShow();

        button.interactable = true;
        image.enabled = true;
        image.sprite = item.sprite; 
        
        if (craftingSlot && playerStats.equippedItems.Contains(item))
        {
            RemoveItem();
        }
    }
    public void AddItem(Item i)
    {
        if (i == null)
        {
            RemoveItem();
            return;
        }

        item = i;

        AddItem();
    }

    public void TestCraftItem()
    {
        InventoryUI.ItemCrafted(this.gameObject);
    }

    public void RemoveItem()
    {
        button.interactable = false;
        image.enabled = false;

        CraftingMaterialsUI.UpdateCraftingUI();

    }

    public void BuyItem()
    {
        playerStats.redMaterials -= item.redCost;
        playerStats.purpleMaterials -= item.purpleCost;
        playerStats.yellowMaterials -= item.yellowCost;
    }

    public void RefundItem()
    {
        playerStats.redMaterials += item.redCost / 2;
        playerStats.purpleMaterials += item.purpleCost / 2;
        playerStats.yellowMaterials += item.yellowCost / 2;

        playerStats.equippedItems.Remove(item);

        RemoveItem();
    }

    private void SendTipToShow()
    {
        string tip = "";
        tip += item.name;
        tip += "\n";
        tip += item.description;


        hoverTip.SetTipToShow(tip);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayerStatsUI.CraftingItemSelected(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlayerStatsUI.CraftingItemUnSelected();
    }
}
