using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class FireballScript : MonoBehaviour
{
    [Header("Components")]
    public GameObject fireballPrefab;
    public Transform firePoint; // Aim Reticles position

    void Start()
    {
        
    }
    
    void Update()
    {
        // Input Actions activates fireball attack's Update things
    }

    public void FireballAttack()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        fireball.GetComponentInChildren<Rigidbody2D>().velocity = firePoint.position * 5f;
    }
}
