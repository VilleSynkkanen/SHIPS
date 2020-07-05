using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TorpedoShooterData : ChargedShooterData
{
    [SerializeField] float launchDelay;

    public float LaunchDelay { get => launchDelay; }
}
