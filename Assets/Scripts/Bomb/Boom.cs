using System;
using UnityEngine;
public class Boom : MonoBehaviour
{
    public AudioSource collisionSound;
    public GameObject explosionPrefab;
    public Transform explosionParticle;
    public Building color;
    private void Start()
    {
        if (color._renderer.material.color == color.colorMaterial)
        {
            Invoke("Explosion", 5f);
        }
    }
    private void Explosion()
    {
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        var explosionPart = Instantiate(explosionParticle);
        explosionPart.transform.position = transform.position;
        Destroy(gameObject);
    }
}

