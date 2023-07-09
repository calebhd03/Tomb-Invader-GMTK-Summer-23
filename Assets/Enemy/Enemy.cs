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
    [SerializeField] EnemyCS enemyCS;
    [SerializeField] GameObject spriteHolder;
    [SerializeField] Animator craftingMaterialAnimator;


    WeaponSwing weaponSwing;
    bool chasingPlayer = false;
    float distanceToPlayer = float.MaxValue;

    // Start is called before the first frame update
    void Start()
    {
        FindWeaponSwing();

        health.SetMaxHealth(enemyCS.maxHealth);
    }

    public void FillOutValues()
    {
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
