using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Image image;


    // Start is called before the first frame update
    void Start()
    {
        AddItem();
    }

    void AddItem()
    {
        image.sprite = item.sprite;
    }

    void CraftItem()
    {

    }
}
