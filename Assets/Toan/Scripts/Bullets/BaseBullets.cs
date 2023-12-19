using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseBullets : MonoBehaviour
{
    [SerializeField] protected int damage;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<IDamagable>() != null)
            {
                other.GetComponent<IDamagable>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }   
    }
}
