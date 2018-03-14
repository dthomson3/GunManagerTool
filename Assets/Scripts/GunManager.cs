using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {

    //reference to the gun from which damage, fire rate, etc are taken from
    [HideInInspector]
    public GunScriptableObject currentGun;

    public int selectedGun;

    [Tooltip("All Weapons the player can currently use")]
    public List<GunScriptableObject> gunInventory = new List<GunScriptableObject>();
    
    [Tooltip("An Empty Game Object that's a child to this which positions the guns without affecting the shoot location")]
    public Transform GunGraphicsParentObject;

    //enables or disables the ability to shoot.
    [HideInInspector]
    public bool canShoot;

    private void Start()
    {
        SetUpGuns();
    }

    public void SetUpGuns()
    {
        //allows the player to shoot and sets the current gun to the first available gun
        canShoot = true;
        foreach (GunScriptableObject gun in gunInventory)
        {
            GameObject newGun = Instantiate(gun.gunGraphics, GunGraphicsParentObject, false);
            if (newGun.transform.Find("GunFiringParticleEffect") == null)
            {
                Debug.LogError("CANNOT FIND OBJECT CALLED " + GunScriptableObject.barrelName + " ON " + newGun.gameObject.name + ". CHECK OBJECT HIERARCHY"); 
            }
            gun.gunFiringEffect = newGun.transform.Find(GunScriptableObject.barrelName).GetComponent<ParticleSystem>();
            newGun.SetActive(false);
        }
        if (gunInventory[0] == null)
        {
            Debug.LogError("First Gun in Gun inventory is null. Check the list on " + gameObject.name + " to see if the list has anything");
        }
        else
        {
            currentGun = gunInventory[0];
        }
    }

    public void Shoot()
    {
        currentGun.gunFiringEffect.Play();
        currentGun.gunFiringEffect.Stop();
        print("FIRE");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, currentGun.range))
        {
            if (hit.collider != null && hit.transform.GetComponent<TakeDamage>() != null)
            {
                print("HIT");
                TakeDamage takeDamage = hit.transform.GetComponent<TakeDamage>();
                currentGun.damageInfo.DoDamage(takeDamage);
            }
        }
    }

    private void Update()
    {
        CheckForSwitchWeapon();
        if (canShoot)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                InvokeRepeating("Shoot", 0f, 1f / currentGun.fireRate);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke("Shoot");
            }
        }
    }

    void CheckForSwitchWeapon()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f)
        {
            if (selectedGun >= GunGraphicsParentObject.childCount - 1)
            {
                selectedGun = 0;
                ChangeWeapon(selectedGun);
            }
            else
            {
                selectedGun++;
                ChangeWeapon(selectedGun);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f)
        {
            if (selectedGun <= 0)
            {
                selectedGun = GunGraphicsParentObject.childCount - 1;
                ChangeWeapon(selectedGun);
            }
            else
            {
                selectedGun--;
                ChangeWeapon(selectedGun);
            }
        }
    }

    public IEnumerator Reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(currentGun.reloadTime);
        canShoot = true;
    }

    public void ChangeWeapon(int _gunValue)
    {
        int index = 0;
        foreach (Transform gun in GunGraphicsParentObject)
        {
            if (index == selectedGun)
            {
                gun.gameObject.SetActive(true);
                currentGun = gunInventory[index];
            }
            else
                gun.gameObject.SetActive(false);
            index++;
        }
        
    }

    public void GiveNewGun(GunScriptableObject _newGun)
    {
        GameObject newGun = Instantiate(_newGun.gunGraphics, GunGraphicsParentObject, false);
        gunInventory.Add(_newGun);
        _newGun.gunFiringEffect = newGun.transform.Find(GunScriptableObject.barrelName).GetComponent<ParticleSystem>();
        newGun.SetActive(false);
    }

    public void RemoveGun(int _gunValue)
    {
        int index = 0;
        foreach (Transform gun in GunGraphicsParentObject)
        {
            if (index == _gunValue)
            {
                Destroy(gun.gameObject);
                ChangeWeapon(selectedGun);
            }
            index++;
        }
    }
}
