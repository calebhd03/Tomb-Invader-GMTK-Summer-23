using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
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

        hoverTip.SetTipToShow(item.tipToShow);

        button.interactable = true;
        image.enabled = true;
        image.sprite = item.sprite;
    }

    public void CraftItem()
    {
        button.interactable = false;
        image.enabled = false;
    }
}
