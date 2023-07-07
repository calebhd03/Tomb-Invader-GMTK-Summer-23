using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputActions : MonoBehaviour
{
    // Script References
    private PlayerController playerMovement;
    private FireballScript fireAttacks;
    private ReticleAimScript reticleAimScript;
    
    // Vectors
    private Vector2 movementInput, aimPos;

    // Input Actions
    [SerializeField]
    private InputActionReference movement, fireball, aimReticle;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerController>(); // PlayerController script
        fireAttacks = GetComponentInChildren<FireballScript>(); // IT GETS FIREBALL CHILD FROM FIRE ATTACKS PARENT!!! IT FIXED ISSUE!!! AHAHAHAHA!!!
        reticleAimScript = GetComponentInChildren<ReticleAimScript>();
    }

    private void OnEnable()
    {
        fireball.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        fireball.action.performed -= PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext obj) // Automatically understands that "PerformAttack" is a method
    {
        fireAttacks.FireballAttack(); // Pay attention to GetComponent area in Awake Method!!
    }

    private void Update()
    {
        NormalMovement();

        // Aiming
        aimPos = ReticleAiming();
        reticleAimScript.aimingPosition = aimPos;
    }

    private void NormalMovement()
    {
        movementInput = movement.action.ReadValue<Vector2>();
        playerMovement.StandardMovement = movementInput; // Calls playercontroller script and gets variable from said script.
    }

    private Vector2 ReticleAiming()
    {
        Vector3 aimPos = aimReticle.action.ReadValue<Vector2>(); // Mouse Input for aiming
        aimPos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(aimPos);
    }
}
