using System;
using System.Collections;
using UnityEngine;

public class TurretDestroyer : MonoBehaviour
{
    public float lifeTime;
    public ParticleSystem boom;
    private void Start()
    {
        Invoke("DestroyTurret", lifeTime);
    }
    void DestroyTurret()
    {
        Instantiate(boom, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
