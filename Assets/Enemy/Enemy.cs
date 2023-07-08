using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;

    [SerializeField] private float health, maxHealth;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Transform target;
    Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        target = GameObject.FindObjectOfType<Player>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = -(target.position - transform.position).normalized;
            moveDir = direction;
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * moveSpeed;
        }
    }

    void TakeDamage(float damageAmount)
    {

    }

    void Die()
    {
        /// <summary>
        /// This method should be executed when conditions are met
        /// It not only kills enemy, but also should drop loot as well
        /// Need to create necessary objects and variables
        /// </summary>
        // What does this line of code mean?
        //for (int  i = 1; i < dropCount; i++)
        //{
            //Instantiate(drop, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        //}
        //parentSpace.spawnPoint = "00000000";
        //Destroy(transform.parent.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // If collider gameobject comes into contact with tag
        // Decrease health
    }

    void OnTriggerStay2D(Collider2D col)
    {
        // Have an else if statement when it comes into contact with tag of sword melee
        // If hit by swoid, get vector/distance between player and enemy, and apply force into whichever direction player is facing
    }
}
