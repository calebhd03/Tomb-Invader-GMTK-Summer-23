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
    [SerializeField] GameObject closeButton;

    [SerializeField] bool craftingSlot = false;

    // Start is called before the first frame update
    void Start()
    {
        AddItem();
    }

    public void AddItem()
    {

        SendTipToShow(false);

        button.interactable = true;
        button.enabled = true;
        image.enabled = true;

        if(item != null)
        {
            image.sprite = item.sprite;
        }

        if(closeButton != null) closeButton.SetActive(true);

        if (craftingSlot && playerStats.equippedItems.Contains(item))
        {
            RemoveItem();
        }
        if (item == null)
        {
            RemoveItem();
            return;
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
        if (closeButton != null) closeButton.SetActive(false);

        button.enabled = false;
        button.interactable = false;
        image.enabled = false;

        SendTipToShow(true);

        CraftingMaterialsUI.UpdateCraftingUI();

    }

    public void BuyItem()
    {
        playerStats.redMaterials -= item.redCost;
        playerStats.purpleMaterials -= item.purpleCost;
        playerStats.yellowMaterials -= item.yellowCost;

        playerStats.damage *= item.damageModifier;
        playerStats.attackSpeed *= item.attackSpeedModifier;
        playerStats.health *= item.healthModifier;
        playerStats.movementSpeed *= item.movementSpeedModifier;

    }

    public void RefundItem()
    {
        playerStats.redMaterials += item.redCost / 2;
        playerStats.purpleMaterials += item.purpleCost / 2;
        playerStats.yellowMaterials += item.yellowCost / 2;

        if (item.damageModifier > 0)
        {
            playerStats.damage *= (item.damageModifier - 1) * 1;
        }
        else
        {
            playerStats.damage *= (Mathf.Abs(item.damageModifier - 1) * 1);
        }

        playerStats.equippedItems.Remove(item);

        RemoveItem();
        CraftingMenuUI.RestockItem(item);
    }

    private void SendTipToShow(bool blank)
    {
        string tip = "";

        if(blank || item == null)
        {
            hoverTip.SetTipToShow(tip);
            return;
        }


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
