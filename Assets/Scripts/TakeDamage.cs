using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    public float health;

    public void DoSingleDamage(float _damage)
    {
        health -= _damage;
    }

    #region BleedDamageVaraibles
    public IEnumerator DoTimedDamage(float _damage, float _timeBetweenTicks, float _repeatNumber, float _initialDelay)
    {
        yield return new WaitForSeconds(_initialDelay);
        for (int i = 0; i < _repeatNumber; i++)
        {
            health -= _damage;
            yield return new WaitForSeconds(_timeBetweenTicks);
        }
    }
    public IEnumerator DoTimedDamage(float[] _damage, float _timeBetweenTicks, float _initialDelay)
    {
        yield return new WaitForSeconds(_initialDelay);
        for (int index = 0; index < _damage.Length; index++)
        {
            health -= _damage[index];
            yield return new WaitForSeconds(_timeBetweenTicks);
        }
    }
    public IEnumerator DoTimedDamage(float _damage, float[] _timeBetweenTicks, float _initialDelay)
    {
        yield return new WaitForSeconds(_initialDelay);
        for (int index = 0; index < _timeBetweenTicks.Length; index++)
        {
            health -= _damage;
            yield return new WaitForSeconds(_timeBetweenTicks[index]);
        }
    }
    public IEnumerator DoTimedDamage(float[] _damage, float[] _timeBetweenTicks, float _initialDelay)
    {
        if (_damage.Length != _timeBetweenTicks.Length)
        {
            Debug.LogError("Damage array and time array are different lengths");
        }
        yield return new WaitForSeconds(_initialDelay);
        for (int index = 0; index < _damage.Length; index++)
        {
            health -= _damage[index];
            yield return new WaitForSeconds(_timeBetweenTicks[index]);
        }
    }
    #endregion

}
