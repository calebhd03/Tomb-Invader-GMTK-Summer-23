using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScarabState
{
    stop,
    idle,
    pursue,
    attack,
    knockedBack,
}

public class TombScarabController : MonoBehaviour
{
    /// <summary>
    /// Tomb Scarabs move towards player, and DO NOT attack
    /// Mindless pawns that just surround player
    /// Also includes simple finite state machine
    /// Manages state of monster and tells it what to do and when to do it
    /// Adjust values in editor
    /// </summary>

    // Scarab Components
    public ScarabState state;
    public Animator animator;

    
    public float chaseDistance;
    public float chaseSpeed;

    public float attackDistance;
    public float attackSpeed;
    public float arcHeight;
    
    public float startTime;

    public float idleSpeed;
    public float idleDistance;
    
    private Vector3 direction;
    private Vector3 destination;
    private Vector3 cleared = new Vector3(-1, -1, -1);
    private Vector3 start;

    // Player References
    private float distanceToPlayer;
    private Transform playerTransform;

    void Start()
    {
        state = ScarabState.idle;
        playerTransform = GameObject.FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < chaseDistance && distanceToPlayer > attackDistance && state == ScarabState.idle)
        {
            state = ScarabState.pursue;
            destination = playerTransform.position;
            animator.Play("move");
        }
        else if (distanceToPlayer < attackDistance && (state == ScarabState.idle || state == ScarabState.pursue))
        {
            state = ScarabState.stop;
            start = transform.position;
            direction = (playerTransform.position - start).normalized;
            destination = start + (direction * attackDistance);
            animator.Play("attack");
        }
        else if (distanceToPlayer > attackDistance && destination == cleared)
        {
            state = ScarabState.idle;
            animator.Play("idle");
            destination = new Vector3(transform.position.x + Random.Range(idleDistance * -1, idleDistance + 2), transform.position.y + Random.Range(idleDistance * -1, idleDistance + 2), 0f);

        }
        
        if (state == ScarabState.idle)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, idleSpeed);
        }
        else if (state == ScarabState.attack)
        {
            // The movement behind the attack...?

            Vector3 center = (start + destination) * 0.5f;

            center -= new Vector3(0, arcHeight, 0);

            Vector3 startRelCenter = start - center;
            Vector3 destinationRelCenter = destination - center;

            float fractionComplete = (Time.time - startTime / 2.0f);

            transform.position = Vector3.Slerp(startRelCenter, destinationRelCenter, fractionComplete);
            playerTransform.position += (Vector3)center;
        }
        else if (state == ScarabState.pursue)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, chaseSpeed);
        }



        if (state != ScarabState.idle || destination == cleared)
        {
            state = ScarabState.idle;
            animator.Play("idle");
            destination = new Vector3(transform.position.x + Random.Range(idleDistance * -1, idleDistance + 2), transform.position.y + Random.Range(idleDistance * -1, idleDistance + 2), 0f);
        }

    }

    void SetToStop()
    {
        state = ScarabState.stop;
    }

    void SetToIdle()
    {
        state = ScarabState.idle;
        destination = cleared;
    }

    void StartAttack()
    {
        state = ScarabState.attack;
        startTime = Time.time;
    }
}
