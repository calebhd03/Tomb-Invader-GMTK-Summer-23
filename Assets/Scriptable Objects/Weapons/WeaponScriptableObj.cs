using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObj", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObj : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }

    //Base stats for the weapon
    [SerializeField] float damage;
    public float Damage { get => damage; private set => damage = value; }

    [SerializeField] float speed;
    public float Speed { get => speed; private set => speed = value; }

    public float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; private set => cooldownDuration = value; }

    [SerializeField] int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }
}
