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
        
    }

    void UpdateItem()
    {
        if(item == null)
        {

        }
        else
        {
            image.sprite = item.sprite;
        }
    }

    void BuyItem()
    {

    }
}
