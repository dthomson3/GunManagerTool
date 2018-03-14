using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageTypes
{
    initialOnly,
    initialWithBleedSameDamageSameTick,
    initialWithBleedManyDamageSameTick,
    initialWithBleedSameDamageManyTick,
    initialWithBleedManyDamageManyTick,
    bleedOnlySameDamageSameTick,
    bleedOnlyManyDamageSameTick,
    bleedOnlySameDamageManyTick,
    bleedOnlyManyDamageManyTick
}

[System.Serializable]
public class DamageInfo
{
    public float bleedDamage;
    public float timeBetweenTicks;

    public float bleedRepeatNumber;

    public float initialDelay;

    public float[] bleedDamageArray;
    public float[] timeBetweenTicksArray;

    public int initialDamage;

    public DamageTypes type;

    public void DoDamage(TakeDamage _target)
    {
        switch (type)
        {
            case DamageTypes.initialOnly:
                _target.DoSingleDamage(initialDamage);
                break;
            case DamageTypes.initialWithBleedSameDamageSameTick:
                _target.DoSingleDamage(initialDamage, initialDelay);
                _target.DoTimedDamage(bleedDamage, timeBetweenTicks, bleedRepeatNumber);
                break;
            case DamageTypes.initialWithBleedManyDamageSameTick:
                _target.DoSingleDamage(initialDamage, initialDelay);
                _target.DoTimedDamage(bleedDamageArray, timeBetweenTicks);
                break;
            case DamageTypes.initialWithBleedSameDamageManyTick:
                _target.DoSingleDamage(initialDamage, initialDelay);
                _target.DoTimedDamage(bleedDamage, timeBetweenTicksArray);
                break;
            case DamageTypes.initialWithBleedManyDamageManyTick:
                _target.DoSingleDamage(initialDamage, initialDelay);
                _target.DoTimedDamage(bleedDamageArray, timeBetweenTicksArray);
                break;
            case DamageTypes.bleedOnlySameDamageSameTick:
                _target.DoTimedDamage(bleedDamage, timeBetweenTicks,bleedRepeatNumber);
                break;
            case DamageTypes.bleedOnlyManyDamageSameTick:
                _target.DoTimedDamage(bleedDamageArray, timeBetweenTicks);
                break;
            case DamageTypes.bleedOnlySameDamageManyTick:
                _target.DoTimedDamage(bleedDamage, timeBetweenTicksArray);
                break;
            case DamageTypes.bleedOnlyManyDamageManyTick:
                _target.DoTimedDamage(bleedDamageArray, timeBetweenTicksArray);
                break;
        }
    }
}

