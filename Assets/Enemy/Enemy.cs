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
    [SerializeField] GameObject WeaponHolder;
    [SerializeField] Health health;
    [SerializeField] EnemyCS enemyCS;
    [SerializeField] GameObject spriteHolder;


    WeaponSwing weaponSwing;
    bool chasingPlayer = false;
    float distanceToPlayer = float.MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        FindWeaponSwing();
        health.SetMaxHealth(enemyCS.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        animator.SetFloat("DistanceToPlayer", distanceToPlayer);
    }

    public void FindWeaponSwing()
    {
        weaponSwing = WeaponHolder.GetComponentInChildren<WeaponSwing>();
    }

    public void WeaponSwong()
    {
        weaponSwing.Swing(enemyCS.damage);
    }

    public void StartChasePlayer()
    {
        chasingPlayer = true;
        navMeshAgent.isStopped = false;
        StartCoroutine(ChasingPlayer());
    }
    public void StopChasePlayer()
    {
        chasingPlayer = false;
        navMeshAgent.isStopped = true;
    }

    public void LookAtPlayer()
    {
        Vector3 oldScale = spriteHolder.transform.localScale;
        if(player.transform.position.x < this.transform.position.x)
        {
            if (oldScale.x >0)
                spriteHolder.transform.localScale = new Vector3(oldScale.x * -1, oldScale.y, oldScale.z); ;
        }
        else
        {
            if (oldScale.x < 0)
                spriteHolder.transform.localScale = new Vector3(oldScale.x * -1, oldScale.y, oldScale.z);
        }

    }

    IEnumerator ChasingPlayer()
    {
        while(chasingPlayer)
        {
            LookAtPlayer();
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
}
