using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextEnemyUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    public static Action<WaveSpawnerScriptableObject> FillList;

    public void FillEnemyList(WaveSpawnerScriptableObject wSO)
    {
        text.text = "";

        if (wSO.tombScarabs > 0)
            text.text += "\nTomb Scarabs " + wSO.tombScarabs;
        if (wSO.sapperAsp > 0)
            text.text += "\nSapper Asps " + wSO.sapperAsp;
        if (wSO.hauntedJar > 0)
            text.text += "\nHaunted Jars " + wSO.hauntedJar;
        if (wSO.boneWarrior > 0)
            text.text += "\nBone Warriors " + wSO.boneWarrior;
        if (wSO.sphinxGolem > 0)
            text.text += "\nSphinx Golems " + wSO.sphinxGolem;
    }

    private void OnEnable()
    {
        FillList += FillEnemyList;
    }
    private void OnDisable()
    {
        FillList -= FillEnemyList;
    }

}
