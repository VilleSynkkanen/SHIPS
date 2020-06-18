using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipMovementData : ScriptableObject
{
    public float moveSpeed;
    public float turnSpeed;
    public float steeringSpeed;
    public float throttleSpeed;
    public float reverseSpeed;
    public float damageAngleCoefficient;
    public float maxDamageEffect;
}
