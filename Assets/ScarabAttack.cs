using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabAttack : MonoBehaviour, Attack
{
    public EnemyCS enemyCS;
    bool attackReady = true;

    public void Attack()
    {

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (attackReady)
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(enemyCS.damage);

                StartCoroutine(AttackCooldown());
                //blood particle from hitting player
            }
        }
    }
    IEnumerator AttackCooldown()
    {
        attackReady = false;
        yield return new WaitForSeconds(enemyCS.attackSpeed);
        attackReady = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.enemyCS = GetComponent<Enemy>().enemyCS;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
