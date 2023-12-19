using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeHeadPlant : BasePlants
{
    protected override void Attack()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * rangeScale, Quaternion.identity, enemyLayer);
        if (hitColliders.Length > 0)
        {
            GameObject target = GetNearestEnemy();
            if (target)
            {
                StartCoroutine(Shoot(target));
                attackCD = attackInterval;
            }
        }
    }

    IEnumerator Shoot(GameObject target)
    {
        GameObject bulletClone1 = Instantiate(bullet, shootTransform.position, Quaternion.identity);
        bulletClone1.GetComponent<BaseBullets>().SetDamage(damage);
        bulletClone1.GetComponent<Rigidbody>().velocity = bulletSpeed * (target.transform.position - transform.position).normalized;
        yield return new WaitForSeconds(0.2f);
        GameObject bulletClone2 = Instantiate(bullet, shootTransform.position, Quaternion.identity);
        bulletClone2.GetComponent<BaseBullets>().SetDamage(damage);
        bulletClone2.GetComponent<Rigidbody>().velocity = bulletSpeed * (target.transform.position - transform.position).normalized;
        yield return new WaitForSeconds(0.2f);
        GameObject bulletClone3 = Instantiate(bullet, shootTransform.position, Quaternion.identity);
        bulletClone3.GetComponent<BaseBullets>().SetDamage(damage);
        bulletClone3.GetComponent<Rigidbody>().velocity = bulletSpeed * (target.transform.position - transform.position).normalized;
    }
}
