using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmountController : MonoBehaviour
{

    [SerializeField]
    private WaveSpawnerScriptableObject wSO;


    void Start()
    {
 
        GenerateWaveSpawn();

        NextEnemyUI.FillList(wSO);
    }

    void GenerateWaveSpawn()
    {
        Debug.Log("Generating Next Wave");

        int randomNumber = Random.Range(0, 3);
        //choose the type of wave
        switch (randomNumber)
        {
            //heavy scarab
            case 0:
                HeavyScarab();
                break;

            //heavy Jar
            case 1:
                HeavyJar();
                break;
            //heavy Bone Warrior
            case 2:
                HeavyWarrior();
                break;
        }
    }    

    void HeavyScarab()
    {
        wSO.tombScarabs = Random.Range(24, 25);
        wSO.hauntedJar = Random.Range(5, 6);
        wSO.boneWarrior = Random.Range(5, 6);
    }

    void HeavyJar()
    {
        wSO.tombScarabs = Random.Range(15, 16);
        wSO.hauntedJar = Random.Range(15, 16);
        wSO.boneWarrior = Random.Range(5, 6);
    }
    void HeavyWarrior()
    {
        wSO.tombScarabs = Random.Range(19, 20);
        wSO.hauntedJar = Random.Range(0, 1);
        wSO.boneWarrior = Random.Range(20, 21);
    }
}
