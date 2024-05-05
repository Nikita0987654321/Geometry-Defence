using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour

{
    public float radius = 5f; // Радиус области вокруг бомбы, в котором будут уничтожаться объекты
    public float timing = 5f;
    void Start()
    {
        Invoke("Explode", timing); // Вызываем метод Explode через 2 секунды
    }

    void Explode()
    {
        // Получаем все коллайдеры в определенном радиусе вокруг бомбы
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        // Уничтожаем все объекты с тегом "Enemy" в радиусе действия
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("Enemy"))
            {
                Destroy(hit.gameObject);
            }
        }

        // Уничтожаем саму бомбу
        Destroy(gameObject);
    }
}

