using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D rb;

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
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.forward);

        Debug.Log(distanceToPlayer);

        animator.SetFloat("DistanceToPlayer", distanceToPlayer);
    }

    public void WalkTowardsPlayer()
    {
        chasingPlayer= true;
        StartCoroutine(ChasingPlayer());
    }

    public void StopWalkingTowardsPlayer()
    {
        chasingPlayer = true;
    }

    IEnumerator ChasingPlayer()
    {
        while(chasingPlayer) 
        {
            Debug.Log("waking towards");

            if(distanceToPlayer > enemyCS.attackDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyCS.chaseSpeed * Time.deltaTime);
            }
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
