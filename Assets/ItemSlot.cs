using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    [SerializeField] Image image;
    [SerializeField] HoverTip hoverTip;
    [SerializeField] Button button;



    // Start is called before the first frame update
    void Start()
    {
        AddItem();
    }

    public void AddItem()
    {
        if (item == null)
            return;
        if (!item.isAvailableToCraft)
            return;

        SendTipToShow();

        button.interactable = true;
        image.enabled = true;
        image.sprite = item.sprite;
    }

    public void CraftItem()
    {
        item.isAvailableToCraft= false;
        button.interactable = false;
        image.enabled = false;
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
        Debug.Log("ENTER!!!");
        PlayerStatsUI.CraftingItemSelected(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlayerStatsUI.CraftingItemUnSelected();
    }
}
