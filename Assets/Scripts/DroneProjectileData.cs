using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DroneProjectileData : ProjectileData
{
    [SerializeField] float turnSpeed;
    [SerializeField] float lifetime;

    public float TurnSpeed { get => turnSpeed; }
    public float Lifetime { get => lifetime; }
}
