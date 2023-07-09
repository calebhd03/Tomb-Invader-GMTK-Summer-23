using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour, Death
{
    // References
    [SerializeField] private PlayerStats stats;
    // Reference Player Controls for when in menu?
    private Rigidbody2D rb;
    private NavMeshAgent navMeshAgent;

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

    // Sword
    public GameObject sword;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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
            navMeshAgent.SetDestination(target.position);
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

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            // Check if sword collides with enemy
            Health enemyHealth = col.GetComponent<Health>();

            if (enemyHealth != null)
            {
                // Apply damage to enemy
                enemyHealth.TakeDamage(5);
            
                // Instantiate sword attack effect at enemy's position
            }
        }
    }

    // Can the attack state machine be run within this script?
    // If so, there can be separate voids that hold code for the indivual weapon attacks

    private void OnDrawGizmosSelected()
    {
        // Attack range sphere
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void Died()
    {
        
    }
}
