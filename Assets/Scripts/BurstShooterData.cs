using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BurstShooterData : ChargedShooterData
{
    [SerializeField] float burstCooldown;
    [SerializeField] int projectileAmount;

    public float BurstCooldown { get => burstCooldown; }
    public int ProjectileAmount { get => projectileAmount; }
}
