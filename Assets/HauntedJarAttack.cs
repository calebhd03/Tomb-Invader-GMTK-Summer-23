using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntedJarAttack : MonoBehaviour, Attack
{
    public EnemyCS enemyCS;
    [SerializeField] GameObject WeaponHolder;
    [SerializeField] Animator animator;
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject bullet;

    public bool attackReady = true;
    WeaponSwing weaponSwing;


    private void Start()
    {
        FindWeaponSwing(); AttackCooldown();
    }
    public void WeaponSwong()
    {
        if (!attackReady) return;

        int nextBulletDirection = Random.Range(0, 121);
        for(int i=0; i<3; i++)
        {
            GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);


            float x = Mathf.Sin(Mathf.PI * nextBulletDirection / 180f);
            float y = Mathf.Cos(Mathf.PI * nextBulletDirection / 180f);


            shot.GetComponent<Bullet>().direction = new Vector3(x, y, 0);
            shot.GetComponent<Bullet>().damage = enemyCS.damage;
            nextBulletDirection += 120;
        }

        StartCoroutine(AttackCooldown());
        animator.SetBool("CanAttack", false);
    }
    public void StopWeaponSwing()
    {
        //animator.SetBool("CanAttack", false);
    }
    public void FindWeaponSwing()
    {

    }

    public void Attack()
    {
    }
    public void Update()
    {
    }

    IEnumerator AttackCooldown()
    {
        attackReady = false;
        yield return new WaitForSeconds(enemyCS.attackSpeed);
        attackReady = true;
    }

}
