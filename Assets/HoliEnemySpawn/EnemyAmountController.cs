using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmountController : MonoBehaviour
{

    [SerializeField]
    private EnemyCS spawnAmount;


    void Start()
    {
        int randomNumber = Random.Range(7, 12);
        spawnAmount.Value = randomNumber;
    }

}
