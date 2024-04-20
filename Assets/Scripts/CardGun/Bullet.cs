using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage = 10;
    private void Start()
    {
        Invoke("DestroyFireball", lifeTime);
    }
    void FixedUpdate()
    {
        MovedFixedUpdate();
    }
    private void OnCollisionEnter(Collision collision)
    {
        EnemyDamage(collision);
        DestroyFireball();
    }
    public void MovedFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }

    private void EnemyDamage(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.health -= damage;
            if (enemyHealth.health <= 0)
            {
                
                Destroy(enemyHealth.gameObject);
            }
        }
    }
}
