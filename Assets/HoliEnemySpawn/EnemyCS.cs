using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy Controller")]
public class EnemyCS : ScriptableObject
{
    //public int enemyAmount;
    //public int enemySpawnLeft:
    [SerializeField]
    private float _value;

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }

}
