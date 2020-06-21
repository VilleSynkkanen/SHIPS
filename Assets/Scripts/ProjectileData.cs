using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProjectileData : ScriptableObject
{
    [SerializeField] int dmg;
    [SerializeField] float angleCoefficient;
    [SerializeField] float minDamage;
    [SerializeField] float explosionForce;

    public int Dmg { get => dmg; }
    public float AngleCoefficient { get => angleCoefficient; }
    public float MinDamage { get => minDamage; }
    public float ExplosionForce { get => explosionForce; }
}
