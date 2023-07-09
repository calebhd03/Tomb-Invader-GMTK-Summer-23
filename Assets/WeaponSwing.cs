using System.Collections.Generic;
using UnityEngine;

public class WeaponSwing : MonoBehaviour
{
    bool notHitYet = false;
    public float damage = 1f;

    public void Swing(float d)
    {
        this.damage= d;
        notHitYet = true;
    }

    public void StopSwing()
    {
        notHitYet= false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if(notHitYet)
        {
            Health health = other.GetComponent<Health>();
            if(health != null)
            {
                Debug.Log("Damage Player");
                health.TakeDamage(damage);
                notHitYet= false;
                
                //blood particle from hitting player
            }
        }
    }
}
