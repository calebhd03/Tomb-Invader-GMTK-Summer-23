using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Enemy[] enemies; // Array of Enemy script instances
    private Transform target; // For finding closest target
    [SerializeField] private float moveSpeed; // If using scriptable stats, replace moveSpeed
    private Vector2 directionToEnemy;
    private Vector2 localScale;

    private float distanceToEnemy;
    private float closestDistance;

    public GameObject sword;

    public float attackRange;
    private float distanceToPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemies = FindObjectsOfType<Enemy>(); // Find all Enemy script instances in the scene
        localScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        // Find the closest enemy with the "Enemy" script attached
        closestDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                target = enemy.transform;
            }
        }

        if (IsPlayerWithinAttackRange())
        {
            PerformAttack();
        }
    }

    private void MovePlayer()
    {
        if (target != null)
        {
            // Get the direction towards the target enemy
            directionToEnemy = (target.position - transform.position).normalized;

            // Move the player towards the target enemy
            rb.velocity = directionToEnemy * moveSpeed;
        }
        else
        {
            // No target found, stop the player's movement
            rb.velocity = Vector2.zero;
        }
    }

    private void LateUpdate()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y);
        }
    }

    bool IsPlayerWithinAttackRange()
    {
        // When player is near target, this bool will activate
        distanceToPlayer = Vector2.Distance(transform.position, target.position);

        return distanceToPlayer <= attackRange;
    }

    void PerformAttack()
    {
        // Play attack animation

        // Perform action

        Debug.Log("Attack performed");
    }

    // Can the attack state machine be run within this script?
    // If so, there can be separate voids that hold code for the indivual weapon attacks

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
