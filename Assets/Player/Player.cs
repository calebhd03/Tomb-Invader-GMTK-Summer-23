using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool awareOfEnemy {get; private set;}
    public Vector2 directionToEnemy {get; private set;}

    // Player Components
    [SerializeField] private float playerChaseDistance; // Have a debug Gizmo void that allows for a visual representation of distance
    private Transform player;
    
    private void Awake()
    {
        player = FindObjectOfType<Enemy>().transform; // Player object searches for any gameobject with Enemy scirpt
    }

    void Update()
    {
        // Get Vector between Player position and Enemy Position
        Vector2 playerToEnemyDistance = player.position - transform.position;
        directionToEnemy = playerToEnemyDistance.normalized;

        // Check if player is close
        if (playerToEnemyDistance.magnitude <= playerChaseDistance)
        {
            awareOfEnemy = true;
        }
        else
        {
            awareOfEnemy = false;
        }
    }
}
