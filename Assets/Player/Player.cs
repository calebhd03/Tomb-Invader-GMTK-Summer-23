using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, Death
{
    // References
    [SerializeField] private PlayerStats stats;
    [SerializeField] WaveSpawnerScriptableObject wSO;
    // Reference Player Controls for when in menu?
    private Rigidbody2D rb;
    private NavMeshAgent navMeshAgent;

    // Enemy Tracking
    public List<GameObject> enemies = new List<GameObject>(); // Array of Enemy script instances (Should this be a list rather than Array?)
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
    public GameObject spriteHolder;
    private Vector2 weaponLocalScale;

    public static Action<GameObject> EnemyAdded;
    public static Action<GameObject> EnemyKilled;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody2D>();

        FillOutValues();
        GetComponent<Health>().SetMaxHealth(stats.health);
    }

    public void FillOutValues()
    {
        navMeshAgent.speed = stats.movementSpeed;
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
        foreach (GameObject enemy in enemies)
        {
            distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                target = enemy.transform;

                LookAtEnemy(enemy);
            }
        }
    }
    public void LookAtEnemy(GameObject enemy)
    {
        Vector3 oldScale = spriteHolder.transform.localScale;
        if (enemy.transform.position.x < this.transform.position.x)
        {
            if (oldScale.x > 0)
            {
                spriteHolder.transform.localScale = new Vector3(oldScale.x * -1, oldScale.y, oldScale.z);
            }
                
        }
        else
        {
            if (oldScale.x < 0)
            {
                spriteHolder.transform.localScale = new Vector3(oldScale.x * -1, oldScale.y, oldScale.z);
            }
        }

    }

    private void MovePlayer()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }


    bool IsPlayerWithinAttackRange()
    {
        // When player is near target, this bool will activate
        distanceToPlayer = Vector2.Distance(transform.position, target.position);

        return distanceToPlayer <= attackRange;
    }

    public void Swing()
    {
        sword.GetComponent<SwordController>().Swing();
    }
    public void StopSwing()
    {
        sword.GetComponent<SwordController>().StopSwing();
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
        // Handle player death

        GetComponent<Animator>().SetTrigger("Died");
        GetComponent<NavMeshAgent>().isStopped= true;
    }

    public void RestartLevel()
    {
        wSO.WavesTried++;

        SceneManager.LoadScene(0);
    }

    public void RemoveEnemyFromList(GameObject e)
    {
        Debug.Log("Remove enemy");
        enemies.Remove(e);
    }
    public void AddEnemyToList(GameObject e)
    {
        Debug.Log("Add enemy");
        enemies.Add(e);
    }

    private void OnEnable()
    {
        EnemyAdded += AddEnemyToList;
        EnemyKilled += RemoveEnemyFromList;
    }

    private void OnDisable()
    {
        EnemyAdded -= AddEnemyToList;
        EnemyKilled -= RemoveEnemyFromList;
    }
}
