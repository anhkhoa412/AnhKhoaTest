using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public List<EffectHolder> statusEffects;
    public Stat moveSpd;

    public void GetDamage(int damage)
    {
        Debug.Log(name + "Get hit" + damage);
    }


    public virtual void ApplyEffect(StatusEffect effect, float amount)
    {
        EffectHolder effectHolder = gameObject.AddComponent<EffectHolder>();
        statusEffects.Add(effectHolder);
        effectHolder.StartEffect(effect, amount);
    }

    public virtual void RemoveEffect(EffectHolder effect)
    {
        statusEffects.Remove(effect);
        Destroy(effect);
    }
}
