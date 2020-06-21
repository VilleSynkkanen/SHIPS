using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChargedShooterData : ShooterData
{
    [SerializeField] float chargeSpeed;
    [SerializeField] float minimumCharge;

    public float ChargeSpeed { get => chargeSpeed; }
    public float MinimumCharge { get => minimumCharge; }
}
