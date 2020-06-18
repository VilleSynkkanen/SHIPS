using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipShooterData : ScriptableObject
{
    public float chargeSpeed;
    public float minimumCharge;
    public float sideShotCooldown;
    public float forwardShotCooldown;
    public float shotForce;
    public float minForce;
    public float maxForce;
    public float rotationVariation;

}
