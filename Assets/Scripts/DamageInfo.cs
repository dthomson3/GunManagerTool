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
    [Tooltip("Every Bleed tick will deal this amount of damage")]
    public float bleedDamage;

    [Tooltip("Delay between when each Bleed Damage will deal damage in seconds")]
    public float timeBetweenTicks;

    [Tooltip("Number of times bleed damage is dealt")]
    public float bleedRepeatNumber;

    [Tooltip("The delay between when the player shoots and when the damage is dealt (in seconds). Put to 0 for no delay")]
    public float initialDelay;

    [Tooltip("An array of how much Bleed Damage each tick will deal")]
    public float[] bleedDamageArray;

    [Tooltip("Delay between when each Bleed Damage will deal damage in seconds")]
    public float[] timeBetweenTicksArray;

    [Tooltip("Amount of damage to be dealt initially. (Seperate from bleed damage)")]
    public int initialDamage;

    
    public DamageTypes WayDamageIsDealt;

    public void DoDamage(HealthManager _target)
    {
        switch (WayDamageIsDealt)
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

