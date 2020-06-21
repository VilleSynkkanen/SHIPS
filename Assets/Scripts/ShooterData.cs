using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShooterData : ScriptableObject
{
    [SerializeField] float shotCooldown;
    [SerializeField] float shotForce;
    [SerializeField] float minForce;
    [SerializeField] float maxForce;
    [SerializeField] float rotationVariation;
    [SerializeField] bool limitedAmmo;
    [SerializeField] int startingAmmo;

    public float ShotCooldown { get => shotCooldown; }
    public float ShotForce { get => shotForce; }
    public float MinForce { get => minForce; }
    public float MaxForce { get => maxForce; }
    public float RotationVariation { get => rotationVariation; }
    public bool LimitedAmmo { get => limitedAmmo; }
    public int StartingAmmo { get => startingAmmo; }
}
