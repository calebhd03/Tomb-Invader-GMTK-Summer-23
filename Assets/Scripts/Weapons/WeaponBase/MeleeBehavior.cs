using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script of all melee behaviours [To be placed on a prefab of a weapon that is melee]
/// </summary>
public class MeleeBehaviour : MonoBehaviour
{
    public WeaponScriptableObj weaponStats;
    public float destroyAfterSeconds;

    //Current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    void Awake()
    {
        currentDamage = weaponStats.Damage;
        currentSpeed = weaponStats.Speed;
        currentCooldownDuration = weaponStats.CooldownDuration;
        currentPierce = weaponStats.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            // Reference enemy scriptable object
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            //enemy.TakeDamage(currentDamage);
        }
    }
}
