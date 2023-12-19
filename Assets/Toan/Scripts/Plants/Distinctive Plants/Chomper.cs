using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Chomper : BasePlants
{
    protected override void Attack()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * rangeScale, Quaternion.identity, enemyLayer);
        if (hitColliders.Length > 0)
        {
            hitColliders[0].gameObject.GetComponent<IDamagable>().TakeDamage(damage);
            attackCD = attackInterval;
        }
    }
}
