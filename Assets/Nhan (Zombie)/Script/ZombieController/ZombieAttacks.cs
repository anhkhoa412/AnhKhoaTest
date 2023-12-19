using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttacks : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float attackSpeed;
    public bool isAttack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plant") || other.gameObject.CompareTag("Tower"))
        {
            Health health = other.GetComponent<Health>();
            isAttack = true;
            if (health != null && isAttack)
            {
                StartCoroutine(DealDamageRepeatedly(health, attackSpeed));
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            isAttack = false;
        }
    }

    IEnumerator DealDamageRepeatedly(Health health, float attackSpeed)
    {
        while (isAttack)
        {
            if (health != null)
            {
                health.TakeDamage(damage);
            } 

            yield return new WaitForSeconds(attackSpeed); 
        }
    }


}
