using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DroneShooterData : ChargedShooterData
{
    [SerializeField] float engineDelay;

    public float EngineDelay { get => engineDelay; }
}
