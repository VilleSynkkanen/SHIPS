using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TorpedoShooterData : ChargedShooterData
{
    [SerializeField] float launchDelay;
    [SerializeField] float activationDelay;

    public float LaunchDelay { get => launchDelay; }
    public float ActivationDelay { get => activationDelay; }
}
