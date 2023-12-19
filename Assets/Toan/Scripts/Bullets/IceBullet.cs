using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : NormalBullet
{
    [SerializeField] StatusEffect DebuffMoveSpd;
    [SerializeField] float DebuffMoveSpdAmount;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            //float finalDebuffSpd = enemy.moveSpd.value * (DebuffMoveSpdAmount / 100);
            //enemy.ApplyEffect(DebuffMoveSpd, finalDebuffSpd);
            Destroy(gameObject);
        }
    }
}
