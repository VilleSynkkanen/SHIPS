using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProjectileData : ScriptableObject
{
    public int dmg;
    public float angleCoefficient;
    public float minDamage;
    public float explosionForce;
}
