using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MineShooterData : ShooterData
{
    [SerializeField] float activationDelay;

    public float ActivationDelay { get => activationDelay; }
}
