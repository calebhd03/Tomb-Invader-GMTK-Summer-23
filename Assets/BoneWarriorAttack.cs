using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneWarriorAttack : MonoBehaviour, Attack
{
    public EnemyCS enemyCS;
    [SerializeField] GameObject WeaponHolder;
    [SerializeField] Animator animator;
    [SerializeField] Enemy enemy;
    
    bool attackReady = true;
    WeaponSwing weaponSwing;

    public void Attack()
    {
        if (attackReady)
            animator.SetBool("CanAttack", attackReady);
    }
    private void Start()
    {
        FindWeaponSwing();
    }

    public void WeaponSwong()
    {
        StartCoroutine(AttackCooldown());
        weaponSwing.Swing(enemyCS.damage);
    }
    public void StopWeaponSwing()
    {
        weaponSwing.StopSwing();
    }
    public void FindWeaponSwing()
    {
        weaponSwing = WeaponHolder.GetComponentInChildren<WeaponSwing>();
    }

    IEnumerator AttackCooldown()
    {
        attackReady = false;
        yield return new WaitForSeconds(enemyCS.attackSpeed);
        attackReady = true;
    }

}
