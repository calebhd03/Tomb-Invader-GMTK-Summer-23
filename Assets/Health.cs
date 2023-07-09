using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health: MonoBehaviour
{
    [SerializeField] GameObject objectToDie;
    [SerializeField] private float currentHealth;
    [SerializeField] AudioSource takeDamageSound;
    [SerializeField] AudioSource diedSound;

    private float maxHealth;



    public float SetMaxHealth()
    {
        this.currentHealth = this.maxHealth;
        return currentHealth;
    }
    public float SetMaxHealth(float maxH)
    {
        this.maxHealth = maxH;
        return this.SetMaxHealth();
    }

    public float GetCurrentHealth()
    {
        return this.currentHealth;
    }

    public float HealAmount(float h)
    {
        this.currentHealth += h;
        return this.currentHealth;
    }
    public float TakeDamage(float damage)
    {
        this.currentHealth -= damage;
        if(this.currentHealth <= 0)
        {
            Died();
        }

        takeDamageSound.Play();

        return this.currentHealth;
    }

    public void Died()
    {
        objectToDie.GetComponent<Death>().Died();
        Debug.Log(this.gameObject.name + " Died");
    }
}
