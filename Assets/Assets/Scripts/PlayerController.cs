using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    // Player RigidBody2D
    private Rigidbody2D rb2d;

    [Header("Movement Variables")]
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float  acceleration = 50;
    [SerializeField] private float  deacceleration = 100;
    [SerializeField] private float currentSpeed = 0;

    // Vectors
    private Vector2 oldMovementInput;
    public Vector2 StandardMovement { get; set; }


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (StandardMovement.magnitude > 0 && currentSpeed >= 0)
        {
            oldMovementInput = StandardMovement;
            currentSpeed += acceleration * maxSpeed * Time.fixedDeltaTime;
        }

        else
        {
            currentSpeed -= deacceleration * maxSpeed * Time.fixedDeltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rb2d.velocity = oldMovementInput * currentSpeed;

        // NOTE: Basic movement works, but I want to add smoothing. Possible through SmoothDamp??
    }
}
