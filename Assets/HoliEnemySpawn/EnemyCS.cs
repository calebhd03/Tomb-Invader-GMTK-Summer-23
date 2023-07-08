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

    public float chaseDistance;
    public float chaseSpeed;

    public float damage;
    public float maxHealth;

    public float attackDistance;
    public float attackSpeed;
    public float arcHeight;

    public float startTime;

    public float idleSpeed;
    public float idleDistance;

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }

}
