using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "New Gun")]
public class GunScriptableObject : ScriptableObject {

    public static string barrelName = "GunFiringParticleEffect";

    [Tooltip("Name of the gun, should you want to display it anywhere")]
    public string gunName;

    [Tooltip("How fast the gun shoots. Put to 0 for the gun to be not automatic. 100 is the fastest fire rate.")]
    [Range(0.0f, 100.0f)]
    public float fireRate;

    [Tooltip("How far the gun can shoot, in world units.")]
    public float range;

    [Tooltip("How long (in seconds) it takes to reload the gun")]
    public float reloadTime;

    [Tooltip("Prefab for the visuals for the gun")]
    public GameObject gunGraphics;

    [HideInInspector]
    public ParticleSystem gunFiringEffect;

    public DamageInfo damageInfo;
}
