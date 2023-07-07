using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleAimScript : MonoBehaviour
{
    public Vector2 aimingPosition { get; set; }

    [Header("Aiming Reticle")]
    public GameObject reticle;
    

    private void Update()
    {
        reticle.transform.localPosition = (aimingPosition-(Vector2)transform.position).normalized;
    }
}
