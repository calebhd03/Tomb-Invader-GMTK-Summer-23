using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] NavMeshAgent navMeshAgent;

    [SerializeField] EnemyCS enemyCS;

    bool chasingPlayer = false;
    float distanceToPlayer = float.MaxValue;

    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        animator.SetFloat("DistanceToPlayer", distanceToPlayer);
    }

    public void StartChasePlayer()
    {
        chasingPlayer = true;
        StartCoroutine(ChasingPlayer());
    }
    public void StopChasePlayer()
    {
        chasingPlayer = false;
    }

    IEnumerator ChasingPlayer()
    {
        while(chasingPlayer)
        {
            navMeshAgent.SetDestination(player.transform.position);
            yield return null;
        }
    }

    void Die()
    {
        /// <summary>
        /// This method should be executed when conditions are met
        /// It not only kills enemy, but also should drop loot as well
        /// Need to create necessary objects and variables
        /// </summary>
        // What does this line of code mean?
        //for (int  i = 1; i < dropCount; i++)
        //{
            //Instantiate(drop, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        //}
        //parentSpace.spawnPoint = "00000000";
        //Destroy(transform.parent.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // If collider gameobject comes into contact with tag
        // Decrease health
    }

    void OnTriggerStay2D(Collider2D col)
    {
        // Have an else if statement when it comes into contact with tag of sword melee
        // If hit by swoid, get vector/distance between player and enemy, and apply force into whichever direction player is facing
    }
}
