using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LossTracker : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    [SerializeField] List<TextMeshProUGUI> lossCounters;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLossTracker();
    }

    public void UpdateLossTracker()
    {

    }
}
