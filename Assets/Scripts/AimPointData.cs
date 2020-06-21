using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AimPointData : ScriptableObject
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxAngle;

    public float RotationSpeed { get => rotationSpeed; }
    public float MaxAngle { get => maxAngle; }
}
