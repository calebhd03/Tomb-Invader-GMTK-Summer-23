using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave Spawner")]
public class WaveSpawnerScriptableObject : ScriptableObject
{
    public int tombScarabs;
    public int sapperAsp;
    public int hauntedJar;
    public int boneWarrior;
    public int sphinxGolem;


    public int WavesTried = 0;
}
