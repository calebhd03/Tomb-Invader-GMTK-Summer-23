using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy Controller")]
public class EnemyCS : ScriptableObject
{

    public float maxHealth;
    public float damage;

    public int monsterBloodGain;
    public int arcaneSandGain;
    public int theoriteGain;

    public float chaseDistance;
    public float chaseSpeed;

    public float attackSpeed;
}
