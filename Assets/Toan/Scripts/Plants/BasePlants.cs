using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlants : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected int attackInterval;
    [SerializeField] protected float attackCD;
    [SerializeField] protected int price;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected Transform shootTransform;
    [SerializeField] protected LayerMask enemyLayer;
    [SerializeField] protected float rangeScale;

    private void Start()
    {
        attackCD = attackInterval;
    }

    private void Update()
    {
        attackCD -= Time.deltaTime;
        if (attackCD <= 0)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * rangeScale, Quaternion.identity, enemyLayer);
        if(hitColliders.Length > 0)
        {
            GameObject target = GetNearestEnemy();
            if (target)
            {
                GameObject bulletClone = Instantiate(bullet, shootTransform.position, Quaternion.identity);
                bulletClone.GetComponent<BaseBullets>().SetDamage(damage);
                bulletClone.GetComponent<Rigidbody>().velocity = bulletSpeed * (target.transform.position - transform.position).normalized;
                attackCD = attackInterval;
            }
        }
    }

    protected GameObject GetNearestEnemy()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        float nearestDistance = float.MaxValue;
        GameObject target = null;
        foreach (var enemy in enemyList)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                target = enemy;
            }
        }
        return target;
    }
}
