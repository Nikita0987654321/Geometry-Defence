using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    private float damage = 10;
    public GameObject turret;
    private void Start()
    {
        damage = turret.GetComponent<GunCard>().Damage;
        Invoke("DestroyFireball", lifeTime);
    }
    void FixedUpdate()
    {
        MovedFixedUpdate();
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyDamage(other);
    }
    public void MovedFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }

    private void EnemyDamage(Collider other)
    {
        var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            DestroyFireball();
            enemyHealth.health -= damage;
            if (enemyHealth.health <= 0)
            {
                Destroy(enemyHealth.gameObject);
            }
        }
    }
}
