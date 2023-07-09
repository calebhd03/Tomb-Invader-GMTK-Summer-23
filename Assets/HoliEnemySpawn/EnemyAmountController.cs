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
        wSO.tombScarabs = Random.Range(10, 11);
        wSO.sapperAsp = Random.Range(20, 21);
        wSO.hauntedJar = Random.Range(3, 4);
        wSO.boneWarrior= Random.Range(6, 7);
        wSO.sphinxGolem = Random.Range(0, 2);
    }

    void HeavyScarab()
    {
        wSO.tombScarabs = Random.Range(24, 25);
        wSO.sapperAsp = Random.Range(3, 4);
        wSO.hauntedJar = Random.Range(5, 6);
        wSO.boneWarrior = Random.Range(5, 6);
        wSO.sphinxGolem = Random.Range(0, 1);
    }

    void HeavyJar()
    {
        wSO.tombScarabs = Random.Range(15, 16);
        wSO.sapperAsp = Random.Range(5, 6);
        wSO.hauntedJar = Random.Range(15, 16);
        wSO.boneWarrior = Random.Range(5, 6);
        wSO.sphinxGolem = Random.Range(0, 1);
    }
    void HeavyWarrior()
    {
        wSO.tombScarabs = Random.Range(19, 20);
        wSO.sapperAsp = Random.Range(0, 1);
        wSO.hauntedJar = Random.Range(0, 1);
        wSO.boneWarrior = Random.Range(20, 21);
        wSO.sphinxGolem = Random.Range(1, 2);
    }
    void HeavyGolem()
    {
        wSO.tombScarabs = Random.Range(36, 37);
        wSO.sapperAsp = Random.Range(0, 1);
        wSO.hauntedJar = Random.Range(0, 1);
        wSO.boneWarrior = Random.Range(0, 1);
        wSO.sphinxGolem = Random.Range(4, 5);
    }
}
