﻿using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float originalSpeed = 0.075f;
    private float speed;
    public float damage = 5;
    private Building _targetBuilding;
    private Base _thisBase;
    void Start()
    {
        RotateEnemy();
    }
    void FixedUpdate()
    {
        EnemyMove();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            Building building = other.GetComponent<Building>();
            Base _base = other.GetComponent<Base>();
            if (building != null)
            {
                _targetBuilding = building;
                StartCoroutine(AttackBuilding());
            }

            if (_base != null)
            {
                _thisBase = _base;
                StartCoroutine(AttackBuilding());
            }
        }
    }
    private IEnumerator AttackBuilding()
    {
        while (_targetBuilding != null && _targetBuilding.health > 0 && _targetBuilding._renderer.material.color == _targetBuilding.colorMaterial)
        {
            speed = 0;
            yield return new WaitForSeconds(1);
            if (_targetBuilding != null)
            {
                _targetBuilding.TakeDamage(damage);
            }

            if (_thisBase != null)
            {
                _thisBase.TakeDamage(damage);
            }
        }

        _thisBase = null;
        _targetBuilding = null;
        speed = originalSpeed;
    }
    public void EnemyMove()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    public void RotateEnemy()
    {
        transform.rotation = Quaternion.Euler(0, -90, 0);
        speed = originalSpeed;
    }
}