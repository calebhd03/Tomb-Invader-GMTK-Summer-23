using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float damage = 0;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction * 10f, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(direction * 10f, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
            Debug.Log("Damage Player " + damage);
            Destroy(this.gameObject);
        }

    }
}
