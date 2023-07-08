using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextEnemyUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    
    public int mummy = 0;
    public int hound = 0;

    public void ClearEnemyList()
    {
        mummy = 0;
        hound = 0;
        text.text = "";
    }

    public void Start()
    {
        FillEnemyList();
    }

    public void FillEnemyList()
    {
        text.text = "";

        if (mummy > 0)
            text.text += "\nMummies " + mummy;
        if (hound > 0)
            text.text += "\nHounds " + hound;
    }

}
