using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShooterData : ScriptableObject
{
    public float shotCooldown;
    public float shotForce;
    public float minForce;
    public float maxForce;
    public float rotationVariation;
    public bool limitedAmmo;
    public int startingAmmo;
}
