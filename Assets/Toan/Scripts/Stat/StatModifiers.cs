using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatModType
{
    Flat = 100,
    PercentAdd = 200,
    PercentMul = 300,
}

public class StatModifiers
{
    public readonly float value;
    public StatModType type;
    public readonly int order;
    public readonly object source;

    public StatModifiers(float value, StatModType type, int order, object source)
    {
        this.value = value;
        this.type = type;
        this.order = order;
        this.source = source;
    }

    public StatModifiers(float value, StatModType type) : this (value, type, (int)type, null) { }

    public StatModifiers(float value, StatModType type, int order) : this(value, type, order, null) { }

    public StatModifiers(float value, StatModType type, object source) : this(value, type, (int)type, source) { }

}
