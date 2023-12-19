using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEBullet : BaseBullets
{
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float scale;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale * scale, Quaternion.identity, enemyLayer);
            foreach (var target in hitColliders)
            {
                target.gameObject.GetComponent<IDamagable>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        Gizmos.DrawWireCube(transform.position, transform.localScale * scale);
    }
}
