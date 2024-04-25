using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    private float damage = 10;
    public ParticleSystem boom;
    private GameObject turret;

    private void Start()
    {
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

    public void SetTurret(GameObject newTurret)
    {
        turret = newTurret;
        damage = turret.GetComponent<GunCard>().Damage;
    }

    private void DestroyFireball()
    {
        Instantiate(boom, transform.position, transform.rotation);
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