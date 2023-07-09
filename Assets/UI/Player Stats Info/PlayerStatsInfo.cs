using TMPro;
using UnityEngine;

public class PlayerStatsInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI modifierText;

    public void setText(float info, float modifier)
    {
        //set modifier text
        //positive modifier
        if(modifier >1)
        {
            modifierText.text = (modifier * 100 - 100).ToString() + "%";
            modifierText.color = Color.green;
        }
        //negative modifier
        else if(modifier < 1)
        {

            modifierText.text = (modifier * 100).ToString() + "%";
            modifierText.color = Color.red;
        }
        else
        {
            //no modifier applied
            modifierText.text = "";
        }

        //set info text
        infoText.text = info.ToString(); 
    }
}
