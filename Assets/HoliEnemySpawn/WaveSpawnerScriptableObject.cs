using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave Spawner")]
public class WaveSpawnerScriptableObject : ScriptableObject
{
    public int value;

    public int WavesTried = 0;
}
