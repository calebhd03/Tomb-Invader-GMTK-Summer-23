using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class CraftingMaterialsUI : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] TextMeshProUGUI red;
    [SerializeField] TextMeshProUGUI purple;
    [SerializeField] TextMeshProUGUI yellow;

    // Start is called before the first frame update
    void Start()
    {
        FillMaterialText();
    }

    public void FillMaterialText()
    {
        red.text = playerStats.redMaterials.ToString();
        purple.text = playerStats.purpleMaterials.ToString();
        yellow.text = playerStats.yellowMaterials.ToString();
    }
}
