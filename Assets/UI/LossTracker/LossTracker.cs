using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LossTracker : MonoBehaviour
{
    [SerializeField] WaveSpawnerScriptableObject waveSpawnerSO;
    [SerializeField] GameObject LossCounter;
    [SerializeField] GameObject LossText;

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
            if(waveSpawnerSO.WavesTried >5)
            {
                LossGame();
                return;
            }
            TextMeshProUGUI text = counters[i];

            text.text = "X";
            text.color = Color.red;
        }
    }

    public void LossGame()
    {
        LossText.SetActive(true);
    }
}
