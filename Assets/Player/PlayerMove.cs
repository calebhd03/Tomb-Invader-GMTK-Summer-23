using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Enemy[] enemies; // Array of Enemy script instances
    private Transform target; // For finding closest target
    [SerializeField] private float moveSpeed; // If using scriptable stats, replace moveSpeed
    private Vector2 directionToEnemy;
    private Vector2 localScale;

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
        float closestDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                target = enemy.transform;
            }
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
}
