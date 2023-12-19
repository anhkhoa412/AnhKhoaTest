using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/DebuffMoveSpd")]
public class DebuffMoveSpd : StatusEffect
{
    float buffAtkAmount;
    StatModifiers statModifiers;

    public override void InitEffect(float amount)
    {
        buffAtkAmount = amount;
    }

    public override void HandleEffect(GameObject parent)
    {
        statModifiers = new StatModifiers(buffAtkAmount, StatModType.Flat, this);
        parent.GetComponent<Enemy>().moveSpd.AddModifier(statModifiers);
        Debug.Log("current Spd: " + parent.GetComponent<Enemy>().moveSpd.value);
    }

    public override void RemoveEffect(GameObject parent)
    {
       parent.GetComponent<Enemy>().moveSpd.RemoveModifier(statModifiers);
    }
}
