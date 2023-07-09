using System.Collections;
using System.Collections.Generic;
using System.Data;
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


    WeaponSwing weaponSwing;
    bool chasingPlayer = false;
    float distanceToPlayer = float.MaxValue;
    bool attackReady = true;

    // Start is called before the first frame update
    void Start()
    {
        FindWeaponSwing();
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
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        bool chasePlayer = distanceToPlayer <= enemyCS.chaseDistance;
        animator.SetBool("ChasePlayer", chasePlayer);
        animator.SetFloat("DistanceToPlayer", distanceToPlayer);
    }

    public void FindWeaponSwing()
    {
        weaponSwing = WeaponHolder.GetComponentInChildren<WeaponSwing>();
    }

    public void WeaponSwong()
    {
        StartCoroutine(AttackCooldown());
        weaponSwing.Swing(enemyCS.damage);
    }

    public void StopWeaponSwing()
    {
        weaponSwing.StopSwing();
    }

    IEnumerator AttackCooldown()
    {
        attackReady = false;
        yield return new WaitForSeconds(enemyCS.attackSpeed);
        attackReady = true;
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

            bool canAttack = false;
            if(distanceToPlayer <= enemyCS.attackDistance + .3 && attackReady) 
                canAttack = true;
            animator.SetBool("CanAttack", canAttack);

            yield return null;
        }
    }

    public void Died()
    {
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
