using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScarabState
{
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
    /// </summary>

    // Scarab Components
    public ScarabState state;
    public Animator animator;

    // Attack Variables
    public float chaseDistance;
    public float attackDistance;

    // Pursuit
    private Vector3 direction;
    private Vector3 destination;

    // Player References
    private float distanceToPlayer;
    private Transform playerTransform;

    void Start()
    {
        state = ScarabState.pursue;
        playerTransform = GameObject.FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < chaseDistance && distanceToPlayer > attackDistance && state == ScarabState.pursue)
        {
            state = ScarabState.pursue;
            destination = playerTransform.position;
            animator.Play("move");
        }
        else if (state == ScarabState.attack)
        {
            // Calculate if player is in proper range
            // Execute attack code here or in another script?
        }
    }
}
