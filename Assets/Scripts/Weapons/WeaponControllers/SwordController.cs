using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Animator animator;

    bool attackReady = true;
    bool attacking = false;

    List<GameObject> enemiesHit = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!attacking) return;

        if (!col.CompareTag("Enemy")) return;

        if (enemiesHit.Contains(col.gameObject)) return;

        enemiesHit.Add(col.gameObject);

        // Check if sword collides with enemy
        Health enemyHealth = col.GetComponent<Health>();

        if (enemyHealth != null)
        {
            // Apply damage to enemy
            enemyHealth.TakeDamage(playerStats.damage);
        }
    }
    public void Swing()
    {
        enemiesHit.Clear();
        StartCoroutine(AttackCooldown());
    }
    public void StopSwing()
    {
        attackReady = true;
        attacking = false;
    }

    public void Update()
    {
        animator.SetBool("CanAttack", attackReady);
    }

    IEnumerator AttackCooldown()
    {
        attacking = true;
        attackReady = false;
        yield return new WaitForSeconds(playerStats.attackSpeed);
    }
}
