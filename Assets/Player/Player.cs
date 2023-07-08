using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // References
    [SerializeField] private PlayerStats stats;
    // Reference Player Controls for when in menu?
    private Rigidbody2D rb;

    // Enemy Tracking
    private Enemy[] enemies; // Array of Enemy script instances (Should this be a list rather than Array?)
    private Transform target; // For finding closest target
    private Vector2 directionToEnemy;
    private Vector2 localScale;
    private float distanceToEnemy;
    private float closestDistance;

    // Attacking
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
        TargetClosestEnemy();
    }

    private void TargetClosestEnemy()
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
            rb.velocity = directionToEnemy * stats.movementSpeed;
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
        // Attack range sphere
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
