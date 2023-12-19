using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{

    public float health;

    public void TakeDamage(float[] damage)
    {
        health -= Random.Range(0, damage.Length);
        if (health <= 0) Destroy(gameObject);
    }
}