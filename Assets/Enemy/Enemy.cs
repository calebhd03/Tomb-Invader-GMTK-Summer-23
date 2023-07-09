using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, Death
{
    [SerializeField] Animator animator;
    public Transform player;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] GameObject WeaponHolder;
    [SerializeField] Health health;
    public EnemyCS enemyCS;
    [SerializeField] GameObject spriteHolder;
    [SerializeField] Animator craftingMaterialAnimator;
    [SerializeField] Attack attackScript;

    public float distanceToPlayer = float.MaxValue;

    bool chasingPlayer = false;
    bool died = false;

    // Start is called before the first frame update
    void Start()
    {
        Player.EnemyAdded(this.gameObject);
        FillOutValues();
        health.SetMaxHealth(enemyCS.maxHealth);
    }

    public void FillOutValues()
    {
        navMeshAgent.speed = enemyCS.chaseSpeed;
        navMeshAgent.stoppingDistance = enemyCS.attackDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (died) return;

        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        bool chasePlayer = distanceToPlayer <= enemyCS.chaseDistance;
        animator.SetBool("ChasePlayer", chasePlayer);
        animator.SetFloat("DistanceToPlayer", distanceToPlayer);
    }

    public void StartChasePlayer()
    {
        if (died) return;
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
        if (died) return;
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

            CheckAttack();

            yield return null;
        }
    }

    public bool CheckAttack()
    {
        if (died) return false;
        if (distanceToPlayer <= enemyCS.attackDistance + .3)
        {
            attackScript = GetComponent<Attack>();
            if (attackScript != null)
            {
                attackScript.Attack();
                return true;
            }
        }
        return false;
    }

    public void Died()
    {

        GetComponent<Collider2D>().enabled= false;
        died = true;

        Player.EnemyKilled(this.gameObject);
        navMeshAgent.isStopped = true;
        animator.SetTrigger("Died");
    }

    public void DisableEnemy()
    {
        this.gameObject.SetActive(false);
    }

    public void PopUpDeathMaterials()
    {
        craftingMaterialAnimator.enabled = true;
    }
}

public interface Attack
{   
    public void Attack();
}
