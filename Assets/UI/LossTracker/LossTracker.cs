using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LossTracker : MonoBehaviour
{
    [SerializeField] WaveSpawnerScriptableObject waveSpawnerSO;
    [SerializeField] GameObject LossCounter;

    List<TextMeshProUGUI> counters;
    private void Start()
    {
        counters = LossCounter.GetComponentsInChildren<TextMeshProUGUI>().ToList<TextMeshProUGUI>();

        FillOutLossCounters();
    }

    public void FillOutLossCounters()
    {
        for(int i=0; i<waveSpawnerSO.WavesTried; i++)
        {
            TextMeshProUGUI text = counters[i];

            text.text = "X";
            text.color = Color.red;
        }
    }
}
