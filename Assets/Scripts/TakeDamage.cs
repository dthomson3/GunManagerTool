using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    public float health;

    public void DoSingleDamage(float _damage)
    {
        health -= _damage;
    }

    public IEnumerator DoSingleDamage(float _damage, float _initialDelay)
    {
        yield return new WaitForSeconds(_initialDelay);
        health -= _damage;
    }

    #region BleedDamageVaraibles
    public IEnumerator DoTimedDamage(float _damage, float _timeBetweenTicks, float _repeatNumber)
    {
        for (int i = 0; i < _repeatNumber; i++)
        {
            yield return new WaitForSeconds(_timeBetweenTicks);
            health -= _damage;
        }
    }
    public IEnumerator DoTimedDamage(float[] _damage, float _timeBetweenTicks)
    {
        for (int index = 0; index < _damage.Length; index++)
        {
            yield return new WaitForSeconds(_timeBetweenTicks);
            health -= _damage[index];
        }
    }
    public IEnumerator DoTimedDamage(float _damage, float[] _timeBetweenTicks)
    {
        for (int index = 0; index < _timeBetweenTicks.Length; index++)
        {
            yield return new WaitForSeconds(_timeBetweenTicks[index]);
            health -= _damage;
        }
    }
    public IEnumerator DoTimedDamage(float[] _damage, float[] _timeBetweenTicks)
    {
        if (_damage.Length != _timeBetweenTicks.Length)
        {
            Debug.LogError("Damage array and time array are different lengths");
        }
        for (int index = 0; index < _damage.Length; index++)
        {
            health -= _damage[index];
            yield return new WaitForSeconds(_timeBetweenTicks[index]);
        }
    }
    #endregion

}
