using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageTypes
{
    initialOnly,
    initialWithBleed,
    bleedOnly
}

[System.Serializable]
public class DamageInfo
{
    public float bleedDamage;
    public float timeBetweenBleeds;
    public float numberOfBleedTicks;
    public float bleedRepeatNumber;
    public float waitPeriod;
    public int initalDamage;
    public DamageTypes type;

    void DoDamage(TakeDamage _target)
    {
        _target.DoSingleDamage(initalDamage);
        _target.DoTimedDamage(bleedDamage, timeBetweenBleeds, bleedRepeatNumber, waitPeriod);
    }
}

