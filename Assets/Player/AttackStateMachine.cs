using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateMachine : MonoBehaviour
{
    // List all States here, so they can be referenced
    public SwordAttack swordAttackState;

    void OnEnable()
    {
        InitializeAttackState();
    }

    public void Update()
    {
        StateMachineRun(nextAttackState); // When this method is called on, it will run the next player state
    }

    public void LateUpdate()
    {

    }

    public delegate void attackState();
    public attackState currentAttackState;
    public attackState nextAttackState;

    void InitializeAttackState()
    {
        nextAttackState = NotAttackingState; // When loaded into game, this is the initial state of player
    }

    void StateMachineRun(attackState stateMethod)
    {
        currentAttackState = stateMethod;
        stateMethod();
    }

    /// <summary>
    /// This is where all player states are listed
    /// Depending on condition, transition to next state from current one
    /// </summary>
    void NotAttackingState()
    {
        // If condition changes, execute "nextAttackState = <attackstatemethod>;"
    }

    void SwordAttackState()
    {
        // If in attack range or in range of enemy
        // 
    }
}
