using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : ScriptableObject
{
    public string effectName;
    public string description;
    public float lifeTime;
    public float tickTime;
    public EffectType effectType;

    public GameObject effectParticle;

    public bool isTickEffect;

    public virtual void InitEffect(float amount) { }

    public virtual void HandleEffect(GameObject parent) { }

    public virtual void RemoveEffect(GameObject parent) { }

}

public enum EffectType {
    Buff,
    Debuff,
    Neutral
}

