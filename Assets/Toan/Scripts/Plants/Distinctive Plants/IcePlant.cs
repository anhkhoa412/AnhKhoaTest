using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlant : BasePlants
{
    protected override void Attack()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * rangeScale, Quaternion.identity, enemyLayer);
        if (hitColliders.Length > 0)
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
}
