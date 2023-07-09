using System.Collections.Generic;
using UnityEngine;

public class WeaponSwing : MonoBehaviour
{
    bool notHitYet = true;
    public float damage = 1f;

    public void Swing(float d)
    {
        this.damage= d;
        notHitYet = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if(notHitYet)
        {
            Health health = other.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(damage);
                notHitYet= false;
                
                //blood particle from hitting player
            }
        }
    }
}
