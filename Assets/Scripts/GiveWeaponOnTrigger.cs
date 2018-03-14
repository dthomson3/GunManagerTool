using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveWeaponOnTrigger : MonoBehaviour
{

    public GunScriptableObject gun;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GunManager>() != null)
        {
            other.GetComponent<GunManager>().GiveNewGun(gun);
        }
        else if (other.GetComponentInChildren<GunManager>() != null)
        {
            other.GetComponentInChildren<GunManager>().GiveNewGun(gun);
        }
    }
}
