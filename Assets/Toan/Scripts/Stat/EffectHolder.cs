using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectHolder : MonoBehaviour
{
    public StatusEffect effect;
    float tickTime;
    float timeOut;
    float currentTime = 0;
    bool isTimeout = false;

    public void StartEffect(StatusEffect statusEffect, float amount)
    {
        effect = statusEffect;
        if (statusEffect.isTickEffect) this.tickTime = statusEffect.tickTime;
        else tickTime = statusEffect.lifeTime;
        timeOut = statusEffect.lifeTime;
        effect.InitEffect(amount);
        StartCoroutine(Begin());
    }

    IEnumerator Begin()
    {
        if (currentTime >= timeOut && !isTimeout)
        {
            isTimeout = true;
            effect.RemoveEffect(gameObject);
            StopAllCoroutines();
            gameObject.GetComponent<Enemy>().RemoveEffect(this);
        }
        if (!isTimeout)
        {
            effect.HandleEffect(gameObject);
            yield return new WaitForSeconds(tickTime);
            currentTime += tickTime;
            StartCoroutine(Begin());
        }
    }

    public void StopEffect()
    {
        isTimeout = true;
        effect.RemoveEffect(gameObject);
        StopAllCoroutines();
        gameObject.GetComponent<Enemy>().RemoveEffect(this);
    }
}
