﻿using UnityEngine;

[CreateAssetMenu]
public class ShotgunShooterData : ChargedShooterData
{
    [SerializeField] int shotAmount;

    public int ShotAmount { get => shotAmount; }
}
