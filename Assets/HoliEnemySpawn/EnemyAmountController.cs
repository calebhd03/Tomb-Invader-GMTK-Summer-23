using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmountController : MonoBehaviour
{

    [SerializeField]
    private WaveSpawnerScriptableObject wSO;


    void Start()
    {
        if(wSO.WavesTried == 0)
        {
            GenerateWaveSpawn();
        }

        NextEnemyUI.FillList(wSO);
    }

    void GenerateWaveSpawn()
    {
        Debug.Log("Generating Next Wave");

        int randomNumber = Random.Range(0, 6);
        //choose the type of wave
        switch (randomNumber)
        {
            //heavy mummies
            case 0:
                HeavyAsp();
                break;

            //heavy scarab
            case 1:
                HeavyScarab();
                break;

            //heavy hounds
            case 2:
                HeavyJar();
                break;
            //heavy hounds
            case 4:
                HeavyWarrior();
                break;
            //heavy hounds
            case 5:
                HeavyGolem();
                break;
        }
    }    

    void HeavyAsp()
    {
        wSO.tombScarabs = Random.Range(1, 5);
        wSO.sapperAsp = Random.Range(7, 13);
        wSO.hauntedJar = Random.Range(0, 3);
        wSO.boneWarrior= Random.Range(0, 3);
        wSO.sphinxGolem = Random.Range(0, 3);
    }

    void HeavyScarab()
    {
        wSO.tombScarabs = Random.Range(9, 11);
        wSO.sapperAsp = Random.Range(3, 6);
        wSO.hauntedJar = Random.Range(0, 3);
        wSO.boneWarrior = Random.Range(0, 3);
        wSO.sphinxGolem = Random.Range(0, 3);
    }

    void HeavyJar()
    {
        wSO.tombScarabs = Random.Range(1, 3);
        wSO.sapperAsp = Random.Range(2, 6);
        wSO.hauntedJar = Random.Range(7, 10);
        wSO.boneWarrior = Random.Range(0, 3);
        wSO.sphinxGolem = Random.Range(0, 3);
    }
    void HeavyWarrior()
    {
        wSO.tombScarabs = Random.Range(1, 3);
        wSO.sapperAsp = Random.Range(2, 6);
        wSO.hauntedJar = Random.Range(0, 3);
        wSO.boneWarrior = Random.Range(7, 10);
        wSO.sphinxGolem = Random.Range(0, 3);
    }
    void HeavyGolem()
    {
        wSO.tombScarabs = Random.Range(1, 3);
        wSO.sapperAsp = Random.Range(2, 6);
        wSO.hauntedJar = Random.Range(0, 3);
        wSO.boneWarrior = Random.Range(0, 3);
        wSO.sphinxGolem = Random.Range(7, 10);
    }
}
