using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class HauntedJarMovement : MonoBehaviour
{
    [SerializeField] EnemyCS enemyCS;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Enemy enemy;
    [SerializeField] float timeBetweenNewPosition;

    Vector3 targetPosition;

    private void Start()
    {
        StartCoroutine(TimeBetweenMove());
        agent.isStopped = false;
    }

    public void Update()
    {
        enemy.LookAtPlayer();
        enemy.CheckAttack();
    }

    IEnumerator TimeBetweenMove()
    {
        agent.stoppingDistance = 1;
        agent.SetDestination(GenerateRandomPosition());
        yield return new WaitForSeconds(timeBetweenNewPosition);
        StartCoroutine(TimeBetweenMove());
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), 0);
        return randomPosition;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
